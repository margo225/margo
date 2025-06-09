using Microsoft.EntityFrameworkCore.Query.Internal;
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
using V2.Forms;
using V2.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        AplicationDbContext context;
        private Inventory inventory;

        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<Inventory> inventories;
        private User _user;
        private ObservableCollection<User> users;

        public User user
        {
            get { return _user; }
            set { _user = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Inventory> Inventories
        {
            get { return inventories; }
            set { inventories = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged ([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }

        public Inventory Inventory
        {
            get { return inventory; }
            set { inventory = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext= this;
            LogInWindow win = new LogInWindow();
            win.ShowDialog();
            GetValue();
        }
        private void GetValue ()
        {
            context = new AplicationDbContext();
            ObservableCollection<Inventory> _inventories = new ObservableCollection<Inventory> (context.inventoryDb.Include(i => i.User));
            Inventories = _inventories;
            OnPropertyChanged ();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddInventoryWindow win  = new AddInventoryWindow();
            win.ShowDialog();
            GetValue();
        }

        private void UpDateButton_Click(object sender, RoutedEventArgs e)
        {
            UpDateInventoryWindow win = new UpDateInventoryWindow(Inventory);
            win.ShowDialog();
            GetValue();
        }

        private void DaleteButton_Click(object sender, RoutedEventArgs e)
        {
            context.inventoryDb.Remove (Inventory);
            context.SaveChanges();
            GetValue();
        }
    }
}