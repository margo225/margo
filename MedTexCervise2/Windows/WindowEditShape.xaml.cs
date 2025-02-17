﻿using System;
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
using MedTexCervise2.Models;

namespace MedTexCervise2.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowEditShape.xaml
    /// </summary>
    public partial class WindowEditShape : Window
    {
        public Models.Shape Shape { get; set; }
        public WindowEditShape(Models.Shape selectShape)
        {
            InitializeComponent();
            StatusBox.ItemsSource = Enum.GetValues(typeof(TypeShapeStatus)).Cast<TypeShapeStatus>();
            TypeBox.ItemsSource = Enum.GetValues(typeof(TupeOb)).Cast<TupeOb>();
            ModelBox.ItemsSource = Enum.GetValues(typeof(ModelOb)).Cast<ModelOb>();
            FirstNameBox.Text = selectShape.FIO.FirstName;
            LastNameBox.Text = selectShape.FIO.LastName;
            PatronymicBox.Text = selectShape.FIO.Patronymic;
            PhoneBox.Text = selectShape.phone;
            DescriptionBox.Text = selectShape.description;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = int.Parse(PhoneBox.Text);
                if (PhoneBox.Text.Length == 11)
                {
                    Shape = new Models.Shape()
                    {
                        DateAdd = DateTime.Now,
                        tupeOb = (TupeOb)TypeBox.SelectedItem,
                        modelOb = (ModelOb)ModelBox.SelectedItem,
                        FIO = new FIO(FirstNameBox.Text, LastNameBox.Text, PatronymicBox.Text),
                        phone = PhoneBox.Text,
                        TypeShapeStatus = TypeShapeStatus.New_shape,
                        description = DescriptionBox.Text
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
