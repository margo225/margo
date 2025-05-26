using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2.Models;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        AplicationDbContext context;
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void ClouseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context = new AplicationDbContext();
                ObservableCollection<Book> books = new ObservableCollection<Book>(context.booksDb);
                bool add = true;
                foreach (Book book in books)
                {
                    if (book.Artikl == ArtiklBox.Text)
                        add = false;
                }
                if (add)
                {
                    Book book = new Book()
                    {
                        Artikl = ArtiklBox.Text,
                        Name = NameBox.Text,
                        Janr = JanrBox.Text,
                        DateOnly = DateOnly.Parse(DatePicker1.Text),
                        Description = DescriptionBox.Text,
                        status = Enums.Status.В_наличии
                    };
                    context.booksDb.Add(book);
                    context.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не верный артикул");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
