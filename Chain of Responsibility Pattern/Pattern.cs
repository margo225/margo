using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility_Pattern
{
    class Request
    {
        public int Int;
        public string operation;
        public Request(int s1, string s2) 
        {
            Int = s1;
            operation = s2;
        }
    }
    abstract class Pattern
    {
        protected string operation;
        public Pattern Successor { get; set; }
        public abstract void HandleRequest(Request request,int Chislo);
    }
    class ConcreteHandlerAdd : Pattern 
    {
        public ConcreteHandlerAdd ()
        {
            operation = "Add";
        }
        public override void HandleRequest(Request request, int Chislo)
        {
            if (operation == request.operation)
            {
                string s = Chislo.ToString() + "+" + request.Int.ToString() + "=" + (Chislo + request.Int).ToString();
                Console.WriteLine(s);
            }
            else if (Successor != null) 
                Successor.HandleRequest(request, Chislo);
        }
    }
    class ConcreteHandlerSub : Pattern
    {
        public ConcreteHandlerSub()
        {
            operation = "Sub";
        }
        public override void HandleRequest(Request request, int Chislo)
        {
            if (operation == request.operation)
            {
                string s = Chislo.ToString() + "-" + request.Int.ToString() + "=" + (Chislo - request.Int).ToString();
                Console.WriteLine(s);
            }
            else if (Successor != null)
                Successor.HandleRequest(request, Chislo);
        }
    }
    class ConcreteHandlerMul : Pattern
    {
        public ConcreteHandlerMul()
        {
            operation = "Mul";
        }
        public override void HandleRequest(Request request, int Chislo)
        {
            if (operation == request.operation)
            {
                string s = Chislo.ToString() + "*" + request.Int.ToString() + "=" + (Chislo * request.Int).ToString();
                Console.WriteLine(s);
            }
            else if (Successor != null)
                Successor.HandleRequest(request, Chislo);
        }
    }
    class ConcreteHandlerDiv : Pattern
    {
        public ConcreteHandlerDiv()
        {
            operation = "Div";
        }
        public override void HandleRequest(Request request, int Chislo)
        {
            if (operation == request.operation)
            {
                string s = Chislo.ToString() + "/" + request.Int.ToString() + "=" + (Chislo / request.Int).ToString();
                Console.WriteLine(s);
            }
            else if (Successor != null)
                Successor.HandleRequest(request, Chislo);
        }
    }
}
