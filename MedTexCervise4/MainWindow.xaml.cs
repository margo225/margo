using System.Collections.ObjectModel;
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
using MedTexCervise2.Windows;
using MedTexCervise2.Models;
using System.Globalization;

namespace MedTexCervise2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Models.Shape SelectItemList { get; set; }
        public static ApplicationContext Contecxt { get; set; } = new ApplicationContext();
        public ObservableCollection<Models.Shape> Shapes { get; set; } = new ObservableCollection<Models.Shape>(Contecxt.Shapes);
        //public ObservableCollection<Models.User> Users { get; set; } = new ObservableCollection<Models.User>(Contecxt.Users);
        public MainWindow()
        { 
            InitializeComponent();
            DataContext = this; //привязка в datacontext все свойста текущкго класса
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            WindowAddShape WinAdd = new();
            if (WinAdd.ShowDialog() == true)
            {
                if (WinAdd.Shape != null)
                {
                    Shapes.Add(WinAdd.Shape);
                }
            }
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (SelectItemList != null)
            {
                WindowEditShape WinEdit = new(SelectItemList);
                if (WinEdit.ShowDialog() == true)
                {
                    if (WinEdit.Shape != null)
                    {
                        var temp = Shapes.FirstOrDefault(q => q.Id == SelectItemList.Id);
                        if (temp != null)
                        {
                            Shapes[Shapes.IndexOf(temp)] = WinEdit.Shape;
                        }
                    }
                }
            }
        }

        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            WindowStatistic WinStat = new(Shapes);
            if (WinStat.ShowDialog() == true)
            {
                
            }
        }
    }
}