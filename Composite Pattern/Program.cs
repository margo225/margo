// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Composite_Pattern;
using System.Net.Http.Headers;

Paragraph paragraph = new Paragraph("Text Text Text");
Section section = new Section("Заголовок");
section.Add(paragraph);
Section section1 = new Section("Заголовок2");
section1.Add(paragraph);
section1.Add(section);
Document document = new Document("Имя документа");
document.Add(section1);
Console.WriteLine(document.Display());
