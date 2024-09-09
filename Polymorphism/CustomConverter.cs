using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    internal class CustomConverter
    {
        internal int Convert(string s, out int a)
        {
            a = Int32.Parse(s);
            return a;
        }
        internal float Convert(string s, out float a)
        {
            a = float.Parse(s);
            return a;
        }
        internal string Convert(int s, out string a)
        {
            a=s.ToString();
            return a;
        }
        internal string Convert(float s, out string a)
        {  
            a=s.ToString(); 
            return a; 
        }
    }
}
