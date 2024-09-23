// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Factory;
using System.Linq.Expressions;

string fileName = "G:\\разработка программных модулей\\Factory\\bd.txt";
List<Creator> loadedCreators = DataManager.Load(fileName);
Console.WriteLine("Данные загружены из файла.");
foreach (var creator in loadedCreators)
{
    switch (creator)
    {
        case Student student:
            Console.WriteLine($"Type: Student, Id: {student.Id}, Name: {student.Name}, Courses: {string.Join(", ", student.Courses)}");
            break;
        case Teacher teacher:
            Console.WriteLine($"Type: Teacher, Id: {teacher.Id}, Name: {teacher.Name}, Experience: {teacher.Experience}, Courses: {string.Join(", ", teacher.Courses)}");
            break;
        case Course course:
            Console.WriteLine($"Type: Course, Id: {course.Id}, Name: {course.Name}, TeacherId: {course.TeacherId}, Students: {string.Join(", ", course.Students)}");
            break;
    }
}