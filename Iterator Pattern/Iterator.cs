using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Iterator_Pattern
{
    internal class Book
    {
        internal string Title { get; set; }
        internal string Author { get; set; }
        internal int Year { get; set; }
        public Book(string title, string author, int year) 
        {
            Title = title;
            Author = author;
            Year = year;
        }
    }
    internal class Library
    {
        List<Book> books = new List<Book>
        {
            new Book ("Война и мир","Лев Толстой",1999),
            new Book("451 градус по Фаренгейту","Рэй Брэдбери",2010)
        };
        public void Add (Book book)
        {
            if (!books.Contains(book))
                books.Add(book);
            else Console.WriteLine("Такая книга уже есть");
        }
        public void Remove(Book book)
        {
            books.Remove (book);
        }
        public string Search(int index)
        {
            string s = "Книга: "+ books[index - 1].Title+", Автор: " + books[index - 1].Author + ", Изданна в " + books[index - 1].Year.ToString();
            return s;
        }
        public int Len()
        { 
            return books.Count; 
        }
    }
}
