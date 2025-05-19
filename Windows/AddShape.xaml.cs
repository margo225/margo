using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddShape.xaml
    /// </summary>
    public partial class AddShape : Window
    {
        public AddShape()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArticlBox.Text.Length == 0 || TypeBox.Text.Length==0 || ShortDescriptionBox.Text.Length==0 || DescriptonBox.Text.Length==0)
            {
                MessageBox.Show("Заполните поля");
            }
            else
            {
                Models.Shape newShape = new Models.Shape()
                {
                    Articl = ArticlBox.Text,
                    Type = TypeBox.Text,
                    ShortDescription = ShortDescriptionBox.Text,
                    Description = DescriptonBox.Text,
                    Status = Enums.Status.на_рассмотрении,
                    DateRegistration = DateOnly.FromDateTime(DateTime.Now)
                };
                AplicationDbContext context = new AplicationDbContext();
                context.shapes.Add(newShape);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}
