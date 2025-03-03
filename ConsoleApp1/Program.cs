// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

int[] arr = new int[10] { 0, 2, 3, 1, 6, 4, 5, 8, 7, 9 };
int a = arr.Length;
int index = 0;
Class1 class1 = new Class1(arr, index);
Console.WriteLine(class1.Print());
class1.ShillSort();
Console.WriteLine(class1.Print());
class1.bSort();
Console.WriteLine(class1.Print());
class1.CombSort();
Console.WriteLine(class1.Print());
