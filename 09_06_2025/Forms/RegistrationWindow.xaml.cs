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
using V2.Models;

namespace V2.Forms
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
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
            AplicationDbContext context = new AplicationDbContext();
            ObservableCollection<User> users = new ObservableCollection<User>(context.usersDb);
            bool add = true;
            foreach (User user in users)
            {
                if (user.Login == LoginBox.Text)
                {  
                    add = false; 
                    break;
                }
            }
            if (add)
            {
                User user = new User()
                {
                    Login = LoginBox.Text,
                    Password = PasswordBox.Text,
                    FIO = FBox.Text + IBox.Text + OBox.Text,
                    PhoneNumber = PhoneNumberBox.Text,
                };
                context.usersDb.Add(user);
                context.SaveChanges();
                MessageBox.Show("Вы зарегистированы!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Логин занят!");
            }
        }
    }
}
