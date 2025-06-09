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
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            AplicationDbContext context = new AplicationDbContext();
            ObservableCollection<User> users = new ObservableCollection<User>(context.usersDb);
            bool exit = true;
            foreach (User user in users)
            {
                if (user.Login == LoginBox.Text && user.Password == PasswordBox.Password)
                {
                    exit = false;
                }
            }
            if (exit)
            {
                MessageBox.Show("Не верные данные");
            }
            else 
            {
                this.Close();
            }
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow win = new RegistrationWindow();
            win.ShowDialog();
        }
    }
}
