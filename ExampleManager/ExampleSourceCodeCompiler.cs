using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExampleManager
{
    class ExampleSourceCodeCompiler
    {
        static string GetSourceFilePathToCompile()
        {
            Console.WriteLine("Reading .cs files");
            List<string> paths = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\"), "*.cs", SearchOption.AllDirectories)
                .Where(
                p =>
                !p.Contains("Program.cs") && !p.Contains("TemporaryGenerated") && !p.Contains("AssemblyInfo.cs")).ToList();
            var targetPath = "";

            for (int i = 0; i < paths.Count; i++)
            {
                var arr = paths[i].Split('\\');
                var fileName = arr[arr.Length - 1];
                Console.WriteLine($"{i} : {fileName}");
            }

            Console.WriteLine("Please choose which file to run:");

            int option = 0;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                return string.Empty;
            }


            if (option >= 0 && option < paths.Count)
            {
                targetPath = paths[option];
            }

            return targetPath;
        }

        static void CompileCodeOnTheFly(string[] args)
        {
            // The built-in CSharpCodeProvider cannot resolve features from C# 6.0 onward
            // Therefore we use roslyn package instead.
            CodeDomProvider codeProvider = new Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider();

            CompilerParameters parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Linq.dll");
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = true;
            parameters.IncludeDebugInformation = true;

            CompilerResults results = codeProvider.CompileAssemblyFromFile(parameters, GetSourceFilePathToCompile());

            if (results.Errors.HasErrors)
            {
                StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                }

                throw new InvalidOperationException(sb.ToString());
            }

            Assembly assembly = results.CompiledAssembly;
            var type = assembly.GetTypes()[0];
            MethodInfo mainMethod = null;

            foreach (var t in assembly.GetTypes())
            {

                var method = t.GetMethod("Main", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

                if (method != null)
                {
                    mainMethod = method;
                    break;
                }
            }

            var methodParameters = mainMethod.GetParameters();
            mainMethod.Invoke(null, methodParameters.Length > 0 ? new object[] { args } : null);
        }
    }
}
