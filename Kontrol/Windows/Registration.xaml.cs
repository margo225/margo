using Kontrol.Models;
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

namespace Kontrol.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        AplicationDbContext context;
        public Registration()
        {
            InitializeComponent();
            context = new AplicationDbContext();
        }

        private void InButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrationButon_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text=="" || PasswordBox.Text=="" || PhoneBox.Text==""|| FBox.Text=="" || IBox.Text=="")
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {
                User newUser = new User()
                {
                    Login = LoginBox.Text,
                    Password = PasswordBox.Text,
                    Phone = PhoneBox.Text,
                    FIO = FBox.Text+IBox.Text+OBox.Text,
                    DateRegistration = DateOnly.FromDateTime(DateTime.Now)
                };
                ObservableCollection<User> Users = new ObservableCollection<User>(context.users);
                bool add = true;
                foreach (User user in Users)
                {
                    if (user.Login == newUser.Login)
                    {
                        add = false;
                        MessageBox.Show("Логин занят");
                    }
                }
                if (add)
                {
                    context.users.Add(newUser);
                    context.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}
