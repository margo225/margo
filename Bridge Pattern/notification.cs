using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern
{
    public interface Inotification
    {
        string Send(string message);
    }
    public class Email : Inotification
    {
        public string  Send (string message)
        {
            return $"Отправка Email: {message}";
        }
    }
    public class SMS : Inotification
    {
        public string Send(string message)
        {
            return $"Отправка SMS: {message}";
        }
    }
    public abstract class notification
    {
        protected Inotification notificationSend;
        protected notification(Inotification notificationSend)
        { 
            this.notificationSend = notificationSend;
        }
        public abstract string Notif (string message);
    }
    public class Text : notification
    {
        public Text (Inotification notificationSend) : base(notificationSend) {}
        public override string Notif(string message)
        {
            string s=notificationSend.Send(message+"\n(text)");
            return s;
        }
    }
    public class HTML : notification
    {
        public HTML(Inotification notificationSend) : base(notificationSend) { }
        public override string Notif(string message)
        {
            string s = notificationSend.Send(message + "\n(html)");
            return s;
        }
    }
}
