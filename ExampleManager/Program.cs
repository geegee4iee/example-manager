using Core.Infrastructure;
using ExampleManager.CompileTimeSource;
using Microsoft.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ExampleManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var exampleClasses = CollectExampleClasses();
            PrintListOfExampleClasses(exampleClasses);
            var selectedExampleIndex = ReadSelectedInputIndex();
            // var options = GetInputArgument();

            var selectedExample = exampleClasses[selectedExampleIndex];

            var runMethod = selectedExample.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).Where(m => m.GetCustomAttribute<ExampleMethodAttribute>() != null || m.Name == "Main").FirstOrDefault();
            var methodParameters = runMethod.GetParameters();

            var exampleMethodAttr = runMethod.GetCustomAttribute<ExampleMethodAttribute>();
            if (exampleMethodAttr != null && exampleMethodAttr.IncludeParams)
            {
                foreach (var parameter in methodParameters)
                {
                    Console.WriteLine($"option: {parameter.Name} - type: {parameter.ParameterType.Name}");
                }

                Console.Write("Do you want to input these options(y/n)?");
                string yn = Console.ReadLine().ToLower().Trim();
                List<object> options = new List<object>();

                if (string.IsNullOrWhiteSpace(yn) || yn == "y")
                {
                    foreach (var parameter in methodParameters)
                    {
                        // object instance = Activator.CreateInstance(parameter.ParameterType);
                        Console.Write($"parameter {parameter.Name} - type[{parameter.ParameterType.Name}]:");
                        var input = Console.ReadLine();
                        try
                        {
                            var convertedObj = Convert.ChangeType(input, parameter.ParameterType);

                            options.Add(convertedObj);
                        }
                        catch (Exception)
                        {
                            options.Add(Activator.CreateInstance(parameter.ParameterType));
                        }
                    }
                }

                runMethod.Invoke(null, methodParameters.Length > 0 ? options.ToArray() : null);
            }
            else
            {
                runMethod.Invoke(null, methodParameters.Length > 0 ? new object[] { args } : null);
            }

            Console.ReadLine();
        }

        static dynamic GetInputArgument()
        {
            Console.Write("Do you have any input options?");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                dynamic d = JsonConvert.DeserializeObject(input);
                return d;
            }

            return null;
        }
        static Type[] CollectExampleClasses()
        {

            var currentAssembly = Assembly.GetExecutingAssembly();

            var location = currentAssembly.Location;
            var assemblyPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            var referencedAssemblies = new List<Assembly>();

            foreach (var path in assemblyPaths)
            {
                var assembly = Assembly.LoadFile(path);
                if (assembly.GetTypes().Any(t => t.GetCustomAttribute<ExampleClassAttribute>() != null))
                    referencedAssemblies.Add(assembly);
            }

            Func<Type, bool> func = t => t.GetCustomAttribute(typeof(ExampleClassAttribute)) != null;

            var types = currentAssembly.GetTypes().Where(func)
                .Union(referencedAssemblies.SelectMany(a => a.GetTypes()).Where(func))
                .ToArray();

            return types;
        }

        static void PrintListOfExampleClasses(Type[] exampleClasses)
        {
            for (int i = 0; i < exampleClasses.Length; i++)
            {
                var exampleAttr = exampleClasses[i].GetCustomAttribute<ExampleClassAttribute>();
                Console.WriteLine($"{i}.{exampleClasses[i].FullName} - description: {exampleAttr.Description}");
            }
        }

        static int ReadSelectedInputIndex()
        {
            Console.WriteLine("Please choose which file to run:");

            int option = 0;
            int.TryParse(Console.ReadLine(), out option);

            return option;
        }




    }
}
