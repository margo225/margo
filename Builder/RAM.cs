using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Builder
{
    internal class RAM
    {
        private int Volume;
        public RAM(int v)
        {
            Volume = v;
        }
        public string String()
        {
            string s = "RAM volume = " + Volume.ToString();
            return s;
        }
    }
}
