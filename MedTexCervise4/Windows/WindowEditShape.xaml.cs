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
using MedTexCervise2.Models;

namespace MedTexCervise2.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowEditShape.xaml
    /// </summary>
    public partial class WindowEditShape : Window
    {
        public Models.Shape Shape { get; set; }
        public int ID;
        public DateTime Dateadd;
        public static ApplicationContext Contecxt { get; set; } = new ApplicationContext();
        public ObservableCollection<Models.User> Users { get; set; } = new ObservableCollection<Models.User>(Contecxt.Users);
        public WindowEditShape(Models.Shape selectShape)
        {
            InitializeComponent();
            ID = selectShape.Id;
            Dateadd = selectShape.DateAdd;
            StatusBox.ItemsSource = Enum.GetValues(typeof(TypeShapeStatus)).Cast<TypeShapeStatus>();
            StatusBox.Text=selectShape.TypeShapeStatus.ToString();
            TypeBox.ItemsSource = Enum.GetValues(typeof(TupeOb)).Cast<TupeOb>();
            TypeBox.Text = selectShape.tupeOb.ToString();
            ModelBox.ItemsSource = Enum.GetValues(typeof(ModelOb)).Cast<ModelOb>();
            ModelBox.Text = selectShape.modelOb.ToString();
            WorkerBox.ItemsSource = Users;
            WorkerBox.Text = selectShape.user.ToString();
            FirstNameBox.Text = selectShape.FIO.FirstName;
            LastNameBox.Text = selectShape.FIO.LastName;
            PatronymicBox.Text = selectShape.FIO.Patronymic;
            PhoneBox.Text = selectShape.phone;
            DescriptionBox.Text = selectShape.description;
            DateBox.Text = selectShape.DateDelivery.ToString();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ulong a = ulong.Parse(PhoneBox.Text);
                if (PhoneBox.Text.Length == 11)
                {
                    Shape = new Models.Shape()
                    {
                        Id = ID,
                        DateAdd = Dateadd,
                        tupeOb = (TupeOb)TypeBox.SelectedItem,
                        modelOb = (ModelOb)ModelBox.SelectedItem,
                        FIO = new FIO(FirstNameBox.Text, LastNameBox.Text, PatronymicBox.Text),
                        phone = PhoneBox.Text,
                        TypeShapeStatus = TypeShapeStatus.New_shape,
                        description = DescriptionBox.Text,
                        DateDelivery = Convert.ToDateTime(DateBox.Text),
                        user = (User)WorkerBox.SelectedItem
                    };
                    this.DialogResult = true;
                }
            }
            catch
            {
                MessageBox.Show("Проверьте заполненные данные");
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
