using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleManager.Interfaces
{
    using static System.Console;
    [ExampleClass]
    class ExplicitlyImplementInterfaceMembers
    {
        interface IInterface1
        {
            void DoWork();
            int A { get; set; }
        }

        interface IInterface2
        {
            void DoWork();
            int A();
        }

        public class ImplementInterface : IInterface1, IInterface2
        {
            public int A { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            int IInterface2.A()
            {
                throw new NotImplementedException();
            }

            public void DoWork()
            {
                WriteLine("Do work on implemented interface");
            }


          

            void IInterface1.DoWork()
            {
                WriteLine("Do work of interface1");
            }

        }


        static void Main()
        {
            var a = new ImplementInterface();

            a.DoWork();
            ((IInterface1)a).DoWork();
            ((IInterface2)a).DoWork();
        }
    }
}
