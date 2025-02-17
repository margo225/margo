using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedTexCervise2.Models
{
    public class Shape
    {
        private static int _lastId = 0;
        public int id {  get; set; }
        public DateTime DateAdd { get; set; } = DateTime.Now;
        public TupeOb tupeOb { get; set; }
        public ModelOb modelOb { get; set; }
        public string description { get; set; }
        public FIO FIO { get; set; }
        public string phone { get; set; }
        public TypeShapeStatus TypeShapeStatus { get; set; }
        public Shape()
        {
            id = ++_lastId;
        }
        public override string ToString()
        {
            return $"Заявка №{id} от {DateAdd}\n" +
                $"Тип оборудования: {tupeOb}\n" +
                $"Модель оборудования: {modelOb}\n" +
                $"Описание проблемы: {description}\n" +
                $"ФИО заказчика: {FIO}\n" +
                $"Статус: {TypeShapeStatus}";
        }
    }
}
