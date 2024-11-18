// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Proxy_Pattern;

Subject subject = new Proxy();
Console.WriteLine((subject as Proxy).Prava("Hi", "admin"));