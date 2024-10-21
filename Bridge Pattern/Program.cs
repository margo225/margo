// See https://aka.ms/new-console-template for more information
using Bridge_Pattern;

Inotification email = new Email();
Inotification sms = new SMS();
notification text = new Text(sms);
notification html = new HTML(email);
Console.WriteLine(text.Notif("my notification for you"));
Console.WriteLine(html.Notif("my notification for you"));
