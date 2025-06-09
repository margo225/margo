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
using V2.Enums;
using V2.Models;

namespace V2.Forms
{
    /// <summary>
    /// Логика взаимодействия для UpDateInventoryWindow.xaml
    /// </summary>
    public partial class UpDateInventoryWindow : Window
    {
        private User _user;
        private ObservableCollection<User> users;
        private Status _status;
        private ObservableCollection<Status> statuses;
        public ObservableCollection<Status> Statuses
        {
            get { return statuses; }
            set { statuses = value; }
        }
        public Status status
        {
            get { return _status; }
            set { _status = value; }
        }
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }
        public User user
        {
            get { return _user; }
            set { _user = value; }
        }
        Inventory inventory;
        public UpDateInventoryWindow(Inventory _inventory)
        {
            InitializeComponent();
            DataContext = this;
            inventory = _inventory;
            ArtiklBox.Text = inventory.Artikl;
            TypeBox.Text = inventory.Type;
            DescriptionBox.Text = inventory.Description;
            DatePicker.Text = inventory.DateOnly.ToString();
            NameBox.Text = inventory.Name;
            ObservableCollection<Status> _statuses = new ObservableCollection<Status>();
            _statuses.Add(Status.выдана);
            _statuses.Add(Status.в_наличии);
            _statuses.Add(Status.на_обслуживании);
            Statuses = _statuses;
            status = inventory.Status;
            AplicationDbContext context = new AplicationDbContext();
            Users = new ObservableCollection<User>(context.usersDb);
            user = inventory.User;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AplicationDbContext context = new AplicationDbContext();
            try
            {
                Inventory inventory2 = new Inventory();
                inventory2.Status = status;
                inventory2.IdUser = user.Id;
                inventory2.Description=DescriptionBox.Text;
                inventory2.Artikl = ArtiklBox.Text;
                inventory2.Type = TypeBox.Text;
                inventory2.Name = NameBox.Text;
                inventory2.DateOnly = DateOnly.Parse(DatePicker.Text);
                context.inventoryDb.Remove(inventory);
                context.inventoryDb.Add(inventory2);
                context.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
