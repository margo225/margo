using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Decorator_Pattern
{
    public abstract class AbstractNotifier
    {
        public abstract string Display(); // возвращает text
    }
    public class Notifier : AbstractNotifier
    {
        protected string text;
        public Notifier (string s)
        {
            text ='"' + s + '"';
        }
        public override string Display()
        {
            return text;
        }
    }
    public abstract class Decorator : AbstractNotifier
    {
        public AbstractNotifier notifier { protected get; set; }
        public override string Display()
        {
            if (notifier != null)
                return notifier.Display();
            else return "Ошибка";
        }
    }
    public class Email : Decorator
    {
        string AddEmail(string text)
        {
            string s = "Отправляем на email         ";
            return s + text;
        }
        public override string Display()
        {
            return AddEmail(base.Display());
        }
    }
    public class SMS : Decorator
    {
        string AddSMS(string text)
        {
            string s = "Отправляем SMS         ";
            return s + text;
        }
        public override string Display()
        {
            return AddSMS(base.Display());
        }
    }
    public class Facebook : Decorator
    {
        string AddFacebook(string text)
        {
            string s = "Отправляем на Facebook         ";
            return s + text;
        }
        public override string Display()
        {
            return AddFacebook(base.Display());
        }
    }
}
