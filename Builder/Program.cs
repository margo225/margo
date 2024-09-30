// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Builder;

var computer = new ComputerBuilder("My Computer").SetCPU("this CPU")
                                .Setmotherboard("this motherboard")
                                .SetRAM(50)
                                .SetvideoCard("this video card")
                                .Setstrorage(100)
                                .Build();
Console.WriteLine(computer.GetDescription());