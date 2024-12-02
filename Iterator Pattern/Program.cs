// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Iterator_Pattern;

Book book = new Book("Стихи","Александр Пушкин",2014);
IEnumerable library = new Library();
IEnumerator cashier = library.GetEnumerator();
while (cashier.MoveNext())
{
    Book bookNew = cashier.Current as Book;
    Console.WriteLine(bookNew.Return());
}
cashier.Add(book);
cashier.Reset();
Console.WriteLine("\n\n");
while (cashier.MoveNext())
{
    Book bookNew = cashier.Current as Book;
    Console.WriteLine(bookNew.Return());
}
