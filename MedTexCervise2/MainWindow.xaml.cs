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

namespace MedTexCervise2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Models.Shape SelectItemList { get; set; }
        public ObservableCollection<Models.Shape> Shapes { get; set; } = new ObservableCollection<Models.Shape>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; //привязка в datacontext все свойста текущкго клвсса
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
                        var temp = Shapes.FirstOrDefault(q => q.id == SelectItemList.id);
                        if (temp != null)
                        {
                            int index = Shapes.IndexOf(temp);
                            Shapes[index] = WinEdit.Shape;
                        }
                    }
                }
            }
        }
    }
}