using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class ExampleMethodAttribute : Attribute
    {
        public ExampleMethodAttribute()
        { }

        public bool IncludeParams { get; set; } = false;
    }
}
