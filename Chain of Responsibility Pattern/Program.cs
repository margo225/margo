// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Chain_of_Responsibility_Pattern;

ConcreteHandlerAdd add = new ConcreteHandlerAdd();
ConcreteHandlerDiv div = new ConcreteHandlerDiv();
ConcreteHandlerMul mul = new ConcreteHandlerMul();
ConcreteHandlerSub sub = new ConcreteHandlerSub();
add.Successor = div;
div.Successor = mul;
mul.Successor = sub;
Request request = new Request(5, "Sub");
add.HandleRequest(request, 2);

