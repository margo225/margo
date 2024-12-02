// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Iterator_Pattern;

Book book = new Book("Стихи","Александр Пушкин",2014);
Library library = new Library();
Console.WriteLine(library.Search(library.Len()));
library.Add(book);
Console.WriteLine(library.Search(library.Len()));
library.Add(book);