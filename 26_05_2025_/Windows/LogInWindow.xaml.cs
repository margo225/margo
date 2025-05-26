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
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        AplicationDbContext context;
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            context=new AplicationDbContext();
            ObservableCollection<User> _users = new ObservableCollection<User>(context.usersDb);
            foreach (User user in _users)
            {
                if (user.Login == LoginBox.Text && user.Password == PasswordBox.Text)
                {
                    MessageBox.Show("Добро пожаловать!");
                    MainWindow.MyUser = user;
                    this.Close();
                }
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow win = new RegistrationWindow();
            win.ShowDialog();
        }
    }
}
