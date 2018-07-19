using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleManager
{
    [ExampleClass]
    class TestGenericType
    {
        abstract class Animal
        {
            public string ItsType { get; set; }
        }

        class Dog: Animal { }

        interface IAnimalList<in K> where K: Animal
        {

            void Bark(K a);
        }

        class DogList<K> : IAnimalList<K> where K: Animal
        {
            public void Bark(K a)
            {
                Console.WriteLine(a.ItsType);
            }
        }

        [ExampleMethod]
        static void Main(string[] args) {
            var dog = new DogList<Animal>();
            IAnimalList<Animal> animalList = dog;
            IAnimalList<Dog> dog2 = animalList;

            dog2.Bark(new Dog() { ItsType = "Lalala" });
        }
    }
}
