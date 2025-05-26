using System;
using System.Collections.Generic;
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
using WpfApp2.Enums;
using System.Collections.ObjectModel;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateBookWindow.xaml
    /// </summary>
    public partial class UpdateBookWindow : Window
    {
        AplicationDbContext context;
        private User? _user;
        private ObservableCollection<User> _users;

        public ObservableCollection<User> users
        {
            get { return _users; }
            set { _users = value; }
        }

        public User? user
        {
            get { return _user; }
            set { _user = value; }
        }

        public UpdateBookWindow(Book book)
        {
            InitializeComponent();
            DataContext = this;
            context = new AplicationDbContext();
            ArtiklBox.Text = book.Artikl;
            DescriptionBox.Text = book.Description;
            JanrBox.Text = book.Janr;
            NameBox.Text = book.Name;
            DatePicker1.Text=book.DateOnly.ToString();
            users = new ObservableCollection<User>(context.usersDb);
            user = book.User;
            StatusBox.ItemsSource = Enum.GetValues(typeof(Status));
            StatusBox.SelectedItem = book.status;
        }

        private void UpDateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClouseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
