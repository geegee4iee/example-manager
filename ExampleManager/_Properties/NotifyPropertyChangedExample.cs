using Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleManager._Properties
{
    [ExampleClass]
    class NotifyPropertyChangedExample
    {
        class Animal : INotifyPropertyChanged
        {
            public string Name
            {
                get => _name;
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                        _name = value;
                    }
                }
            }

            private string _name;
            public event PropertyChangedEventHandler PropertyChanged;
        }

        static void Main()
        {
            var animal = new Animal();
            animal.PropertyChanged += OnPropertyChanged;
            animal.Name = "Ryu";
        }

        private static void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender.GetType() == typeof(Animal))
            {
                Console.WriteLine($"Property {e.PropertyName} of instance of class {nameof(Animal)} has been changed");
            }
        }
    }
}
