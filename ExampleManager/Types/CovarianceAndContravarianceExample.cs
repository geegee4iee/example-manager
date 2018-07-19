using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExampleManager.Types.CovarianceAndContravarianceExample;

namespace ExampleManager.Types
{
    [ExampleClass]
    public class CovarianceAndContravarianceExample
    {
        public class Animal
        {
            public string Name { get; set; }

            public Animal(string name)
            {
                this.Name = name;
            }
        }

        public class Cat:Animal
        {
            public Cat(string name):base(name)
            {
                
            }
        }

        public class BigCat : Cat
        {
            public BigCat(string name) : base(name)
            {
            }
        }

        void CompareCats(IComparer<Cat> comparer)
        {
            var cat1 = new Cat("Jogn");
            var cat2 = new Cat("Lyly");

            comparer.Compare(cat1, cat2);
        }



        internal class CompareAnimals : IComparer<Animal>
        {
            public int Compare(Animal x, Animal y)
            {
                return x.Name.Length - y.Name.Length;
            }

            public int Compare(Cat x, Cat y)
            {
                throw new NotImplementedException();
            }

            public int Compare(BigCat x, BigCat y)
            {
                throw new NotImplementedException();
            }
        }

        static void Main()
        {

            IComparer<BigCat> compareAnimals = new CompareAnimals();
        }
    }

   
}
