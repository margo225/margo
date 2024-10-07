// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Adapter_Pattern;
ComputerGame computerGame = new ComputerGame("Name", PegiAgeRating.P12,159,2048,2,2,2,2);
Adapter adapter = new Adapter(computerGame);
Console.WriteLine(adapter.getTitle());
Console.WriteLine(adapter.isTripleAGame());
Console.WriteLine(adapter.getPegiAllowedAge());
Console.WriteLine(adapter.getRequirementsToString());