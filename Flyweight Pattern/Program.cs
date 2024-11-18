// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Flyweight_Pattern;

CharacterFactory factory = new CharacterFactory();
Character a=factory.GetFyweight("four", 3, "G:/home/four3.img");
Character b = factory.NewLewel("one", 1);
Console.WriteLine(a.toString());
Console.WriteLine(b.toString());
