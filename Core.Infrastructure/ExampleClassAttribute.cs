using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class ExampleClassAttribute : Attribute
    {
        private string _description;

        public ExampleClassAttribute()
        {
        }

        public ExampleClassAttribute(string description)
        {
            this._description = description;
        }

        public string Description { get => _description; set => _description = value; }
    }
}
