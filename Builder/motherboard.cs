using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class motherboard
    {
        private string Name;
        public motherboard(string s)
        {
            Name = s;
        }
        public string String()
        {
            string s = "motherboard: " + Name;
            return s;
        }
    }
}
