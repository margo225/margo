// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Decorator_Pattern;

string text = "Новое соощение";
AbstractNotifier notifier = new Notifier(text);
Decorator email = new Email();
Decorator sms = new SMS();
Decorator facebook = new Facebook();
email.notifier = notifier;
sms.notifier = email;
facebook.notifier = sms;
Console.WriteLine(facebook.Display());