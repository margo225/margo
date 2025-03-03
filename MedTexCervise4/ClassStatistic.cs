using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedTexCervise2.Models;

namespace MedTexCervise2
{
    public class ClassStatistic
    {
        public static ApplicationContext Contecxt { get; set; } = new ApplicationContext();
        public ObservableCollection<Models.User> Users { get; set; } = new ObservableCollection<Models.User>(Contecxt.Users);
        public string TupeMetod (ObservableCollection<Models.Shape> Shapes)
        {
            int[] mas = new int[2];
            foreach (var shape in Shapes)
            {
                if (shape.tupeOb == TupeOb.Узи)
                {
                    mas[0]++;
                }
                else
                {
                    mas[1]++;
                }
            }
            return $"Заявок на тип {TupeOb.Узи} - {mas[0]}, на тип {TupeOb.Рентген} - {mas[1]}";
        }
        public string ModelMetod(ObservableCollection<Models.Shape> Shapes)
        {
            int[] mas = new int[2];
            foreach (var shape in Shapes)
            {
                if (shape.modelOb == ModelOb.AB)
                {
                    mas[0]++;
                }
                else
                {
                    mas[1]++;
                }
            }
            return $"Заявок на модель {ModelOb.AB} - {mas[0]}, на модель {ModelOb.BC} - {mas[1]}";
        }
        public string UserMetod(ObservableCollection<Models.Shape> Shapes)
        {

            int[] mas = new int[Users.Count()+1];
            foreach (var shape in Shapes)
            {
                bool no = true;
                for (int i = 0; i < mas.Length-1; i++)
                {
                    if (shape.user == Users[i])
                    {
                        mas[i]++;
                        no = false;
                    }
                }
                if (no)
                {
                    mas[Users.Count()]++;
                }
            }
            string S = "\n";
            for (int i = 0; i < mas.Length-1; i++)
            {
                S += mas[i] + $" - Заявлений с рабочим {Users[i].ToString()}\n";
            }
            S += $"{mas[Users.Count()]} - Заявлений без рабочих";
            return S;
        }
    }
}
