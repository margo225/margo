using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Pattern
{
    public interface Subject
    {
        string Request(string request);
    }
    public class RealSubject : Subject
    {
        public string Request(string request)
        {
            return request+" in RealSubject";
        }
    }
    public class Proxy : Subject
    {
        RealSubject realSubject;
        public string Request (string request)
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            return realSubject.Request(request);
        }
        public string Prava(string request, string rights)
        {
            if (rights == "admin")
                return Request(request);
            else
                return "У вас нет прав для использования этой функции";
        }
    }
}
