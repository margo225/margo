using Microsoft.Extensions.DependencyModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Models;
using WpfApp2.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        AplicationDbContext context;
        public static User MyUser;
        private Book _book;
        private ObservableCollection<Book> _books;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Book book
        {
            get { return _book; }
            set { _book = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Book> books
        {
            get { return _books; }
            set { _books = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LogInWindow window = new LogInWindow();
            window.ShowDialog();
            GetValue();
        }
        private void GetValue()
        {
            context = new AplicationDbContext();
            books = new ObservableCollection<Book>(context.booksDb);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow win = new AddBookWindow();
            win.ShowDialog();
            GetValue();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            context = new AplicationDbContext();
            context.booksDb.Remove(book);
            context.SaveChanges();
            GetValue();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateBookWindow win = new UpdateBookWindow(book);
            win.ShowDialog();
            GetValue();
        }
    }
}