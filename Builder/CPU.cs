using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class CPU
    {
        private string Name;
        public CPU(string s) 
        { 
            Name = s;
        }
        public string String()
        {
            string s = "CPU: " + Name;
            return s;
        }
    }
}
