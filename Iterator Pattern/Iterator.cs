using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Iterator_Pattern
{
    interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }
    interface IEnumerator
    { 
        bool MoveNext();
        void Reset();
        object Current { get; }
        void Add(Book book);
    }
    class Library : IEnumerable
    {
        List<Book> books = new List<Book>
        {
            new Book ("Война и мир","Лев Толстой",1999),
            new Book("451 градус по Фаренгейту","Рэй Брэдбери",2010)
        };
        public Book this[int index]
        {
            get { return books[index]; }
            set {  books.Insert(index, value); }
        }
        public int Count
        { 
            get { return books.Count; } 
        }
        public IEnumerator GetEnumerator()
        {
            return new Cashier(this);
        }
        public void Add(Book book)
            { books.Add(book); }
    }
    class Cashier : IEnumerator
    {
        private Library library;
        private int current = -1;
        public Cashier (Library enumerable)
        {
            this.library = enumerable;
        }
        public bool MoveNext()
        {
            if (current<library.Count -1)
            {
                current++;
                return true;
            }
            return false;
        }
        public void Reset()
        {
            current = -1;
        }
        public object Current
        { get { return library[current]; } }
        public void Add(Book book)
        {
            library.Add(book);
        }
    }
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
        public string Return()
        {
            string s= "Книга: "+ Title+", Автор: " + Author + ", Изданна в " + Year.ToString();;
            return s;
        }
    }
}
