using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    internal abstract class Product
    {
        internal string Name { get; set; }
        internal abstract string GetInformation();
        internal virtual double Price { get; set; }
    }

    internal class Toy : Product
    {
        internal int Age { get; set; }
        internal override double Price 
        {
            get { return base.Price * 0.9; }
        }
        internal override string GetInformation()
        {
            return $"Название {Name}, Возраст {Age}, Цена {Price}";
        }
    }
    internal class Meat : Product
    {
        internal int type { get; set; }
        internal override double Price
        {
            get { return base.Price * 0.8; }
        }
        internal override string GetInformation()
        {
            return $"Название {Name}, тип {type}, Цена {Price}";
        }
    }
    internal class Drink : Product
    {
        internal int V { get; set; }
        internal override double Price
        {
            get { return base.Price * 0.85; }
        }
        internal override string GetInformation()
        {
            return $"Название {Name}, оъем {V}, Цена {Price}";
        }
    }
    internal class Car : Product
    {
        internal int Color { get; set; }
        internal override double Price
        {
            get { return base.Price * 0.75; }
        }
        internal override string GetInformation()
        {
            return $"Название {Name}, цвет {Color}, Цена {Price}";
        }
    }
    internal class fruits : Product
    {
        internal int day { get; set; }
        internal override double Price
        {
            get { return base.Price * 0.85; }
        }
        internal override string GetInformation()
        {
            return $"Название {Name}, день поставки {day}, Цена {Price}";
        }
    }

}
