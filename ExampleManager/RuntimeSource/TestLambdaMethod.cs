using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleManager
{
    [ExampleClass(Description = "Lambda Method Running Example")]
    class TestLambdaMethod
    {
        [ExampleMethod]
        static void Main(string[] args)
        {
            Action a = () => { Console.WriteLine("I called you!!"); };

            a();
        }
    }
}
