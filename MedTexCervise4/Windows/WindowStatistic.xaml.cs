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

namespace MedTexCervise2.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowStatistic.xaml
    /// </summary>
    public partial class WindowStatistic : Window
    {
        ClassStatistic classStatistic = new ClassStatistic();
        public WindowStatistic(ObservableCollection<Models.Shape> Shapes)
        {
            InitializeComponent();
            TextBlock.Text = TextBlock.Text + "\n" + classStatistic.TupeMetod(Shapes);
            TextBlock.Text = TextBlock.Text + "\n" + classStatistic.ModelMetod(Shapes);
            TextBlock.Text = TextBlock.Text + "\n" + classStatistic.UserMetod(Shapes);

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
