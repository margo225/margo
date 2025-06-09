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
using V2.Models;

namespace V2.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddInventoryWindow.xaml
    /// </summary>
    public partial class AddInventoryWindow : Window
    {
        public AddInventoryWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AplicationDbContext context = new AplicationDbContext();
                Inventory newInventory = new Inventory()
                {
                    Artikl = ArtiklBox.Text,
                    Type = TypeBox.Text,
                    Name = NameBox.Text,
                    Description = DescriptionBox.Text,
                    DateOnly = DateOnly.Parse(DatePicker.Text),
                    Status = Enums.Status.в_наличии
                };
                context.inventoryDb.Add(newInventory);
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
