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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        AplicationDbContext context;
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context = new AplicationDbContext();
                ObservableCollection<User> users = new ObservableCollection<User>(context.usersDb);
                bool Add = true;
                foreach (User user in users)
                {
                    if (user.Login == LoginBox.Text)
                    {
                        Add = false;
                    }
                }
                if (Add)
                {
                    User user = new User()
                    {
                        Login = LoginBox.Text,
                        Password = PasswordBox.Text,
                        FIO = FIOBox.Text,
                        Phone = PhoneBox.Text,
                        Registration = DateOnly.Parse(DateTime.Now.ToShortDateString())
                    };
                    context.usersDb.Add(user);
                    context.SaveChanges();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Логин занят!");
                }
            } catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
