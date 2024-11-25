// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Command_Pattern;

Editor editor = new Editor();
string result = "";
result = editor.Add("Hi! How are you?");
Console.WriteLine(result);
result = editor.Sub("Hi!");
Console.WriteLine(result);
result = editor.Undo(1);
Console.WriteLine(result);