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
using Kontrol.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Kontrol.Windows
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        } 

        private void ButtonRegistraion_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void ButtonIn_Click(object sender, RoutedEventArgs e)
        {
            AplicationDbContext context = new AplicationDbContext();
            ObservableCollection<User> users = new ObservableCollection<User>(context.users);
            int close = 0;
            foreach (User user in users)
            {
                if (user.Login == LoginBox.Text && user.Password == PasswordBox.Text)
                {
                    MainWindow.MyUser = user;
                    close=1;
                }
            }
            if (close==0)
                MessageBox.Show("Проверьте данные!");
            else
                this.Close();
        }
    }
}
