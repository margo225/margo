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
    /// Логика взаимодействия для UpDateShape.xaml
    /// </summary>
    public partial class UpDateShape : Window
    {
        Models.Shape _shape;
        private User _user;
        private ObservableCollection<User> _userList;
        private Enums.Status _status;
        private ObservableCollection<Enums.Status> _statusList;
        public Enums.Status Statuses
        {
            get { return _status; }
            set { _status = value; }
        }

        public ObservableCollection<Enums.Status> StatusesList
        {
            get { return _statusList; }
            set { _statusList = value; }
        }

        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set { _userList = value; }
        }

        public User Users
        {
            get { return _user; }
            set { _user = value; }
        }

        public UpDateShape(Models.Shape shape)
        {
            InitializeComponent();
            _shape = shape;
            GetValue();
        }
        private void GetValue ()
        {
            AplicationDbContext context = new AplicationDbContext();
            ArticlBox.Text = _shape.Articl;
            TypeBox.Text = _shape.Type;
            DescriptonBox.Text = _shape.Description;
            ShortDescriptionBox.Text = _shape.ShortDescription;
            UserList = new ObservableCollection<User>(context.users);
            Users = _shape.User;
            StatusesList = new ObservableCollection<Enums.Status>() { Enums.Status.выполнено, Enums.Status.в_исполнении, Enums.Status.на_рассмотрении };
            Statuses =_shape.Status;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
