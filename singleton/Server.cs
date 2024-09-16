using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace singleton
{
    internal class ServerLazy
    {
        static ServerLazy uniqueInstance;
        private static object syncRoot = new object();
        static List<string> serversHTTP = new List<string>();
        static List<string> serversHTTPS = new List<string>();
        internal ServerLazy() { }
        internal static ServerLazy Instance()
        {
            Thread.Sleep(500);
            if (uniqueInstance == null)
            {
                lock (syncRoot)
                {
                    if (uniqueInstance == null)
                        uniqueInstance = new ServerLazy();
                }
            }
            return uniqueInstance;
        }
        internal static bool Add(string s)
        {
            if (s.Substring(0, 5) == "https")
            {
                foreach (string elem in serversHTTPS)
                {
                    if (elem == s) return false;
                }
                return true;
            }
            else 
            {
                if (s.Substring(0, 4) == "http")
                {
                    foreach (string elem in serversHTTP)
                    {
                        if (elem == s) return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        internal static List<string> GetServersHTTP()
        { 
            return serversHTTP;
        }
        internal static List<string> GetServersHTTPS()
        {
            return serversHTTPS;
        }
    }
    internal class ServerEager
    {
        static ServerEager uniqueInstance = new ServerEager();
        private static object syncRoot = new object();
        static List<string> serversHTTP = new List<string>();
        static List<string> serversHTTPS = new List<string>();
        internal ServerEager() { }
        internal static ServerEager Instance()
        {
            return uniqueInstance;
        }
        internal static bool Add(string s)
        {
            if (s.Substring(0, 5) == "https")
            {
                foreach (string elem in serversHTTPS)
                {
                    if (elem == s) return false;
                }
                return true;
            }
            else
            {
                if (s.Substring(0, 4) == "http")
                {
                    foreach (string elem in serversHTTP)
                    {
                        if (elem == s) return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        internal static List<string> GetServersHTTP()
        {
            return serversHTTP;
        }
        internal static List<string> GetServersHTTPS()
        {
            return serversHTTPS;
        }
    }
}
