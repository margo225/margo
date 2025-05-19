using Kontrol.Models;
using Kontrol.Windows;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace Kontrol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AplicationDbContext context;
        public static User MyUser {  get; set; }
        private Models.Shape _shape;
        private ObservableCollection<Models.Shape> _shapeList;

        public Models.Shape Shapes
        {
            get { return _shape; }
            set { _shape = value; }
        }

        public ObservableCollection<Models.Shape> ShapesList
        {
            get { return _shapeList; }
            set { _shapeList = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            context= new AplicationDbContext();
            ShapesList = new ObservableCollection<Models.Shape>(context.shapes);
            Login log = new Login();
            log.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddShape win = new AddShape();
            win.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpDateShape win = new UpDateShape(Shapes);
            win.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            context.shapes.Remove(Shapes);
            context.SaveChanges();
        }
    }
}