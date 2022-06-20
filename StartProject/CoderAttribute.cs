using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class CoderAttribute : Attribute
    {
        private string name;

        public CoderAttribute() 
        {
            name = "default";
        }

        public CoderAttribute(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"Coder {name}";
        }
    }
}
