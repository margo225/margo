// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Factory;
using System.Linq.Expressions;

string path = "G:\\разработка программных модулей\\Factory\\bd.txt";
List<Course> courseList = new List<Course>();
List<Student> StudentList = new List<Student>();
List<Teacher> TeacherList = new List<Teacher>();

using (StreamReader reader = new StreamReader(path))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        int indx = line.IndexOf("ID", 0, line.Length) + 5;
        string id = line[indx].ToString();
        while (line[indx+1]!=';')
        {
            id += line[indx + 1];
            indx++;
        }
        indx = line.IndexOf("Name", 0, line.Length) + 7;
        string name = line[indx].ToString();
        while (line[indx + 1] != ';')
        {
            name += line[indx + 1];
            indx++;
        }
        indx = line.IndexOf("Teaher-id", 0, line.Length);
        string dop="";
        if (indx != -1)
        {
            indx += 12;
            dop = line[indx].ToString();
        }
        else
        {
            indx = line.IndexOf("Experience", 0, line.Length);
            if (indx != -1)
            {
                indx += 13;
                dop = line[indx].ToString();
            }
        }
        while (line[indx + 1] != ';' && indx!=-1)
        {
            dop += line[indx + 1];
            indx++;
        }
        string[] words = line.Split(',');
        switch (line[0])
        {
            case 'C': Course cours = new Course(int.Parse(id),name,int.Parse(dop));
                for (int i = 1;i<words.Length;i++)
                {
                    cours.Add(int.Parse(words[i]));
                }
                courseList.Add(cours); break;
            case 'T': Teacher teacher = new Teacher(int.Parse(id), name, int.Parse(dop));
                for (int i = 1; i < words.Length; i++)
                {
                    teacher.Add(int.Parse(words[i]));
                }
                TeacherList.Add(teacher); break;
            case 'S': Student student = new Student(int.Parse(id), name);
                for (int i = 1; i < words.Length; i++)
                {
                    student.Add(int.Parse(words[i]));
                }
                StudentList.Add(student); break;
        }
        foreach (Student student in StudentList)
        {
            foreach (Course course in courseList)
            { 
                student.Cours(course);
            }
        }
        foreach (Teacher teacher in TeacherList)
        {
            foreach (Course course in courseList)
            {
                teacher.Cours(course);
            }
        }
        foreach (Course course in courseList)
        {
            foreach (Student student in StudentList)
            {
                course.Cours(course);
            }
        }
    }
}