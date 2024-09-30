using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class storage
    {
        private int Volume;
        public storage(int v)
        {
            Volume = v;
        }
        public string String()
        {
            string s = "strorage volume = " + Volume.ToString();
            return s;
        }
    }
}
