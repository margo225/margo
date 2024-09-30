using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class videoCard
    {
        private string Name;
        public videoCard(string s)
        {
            Name = s;
        }
        public string String()
        {
            string s = "video card: " + Name;
            return s;
        }
    }
}
