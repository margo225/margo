using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public abstract class Creator
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract void Save(StreamWriter writer);
        public abstract void Load(Dictionary<string, string> data);
    }

    public class Student : Creator
    {
        public List<int> Courses { get; set; } = new List<int>();

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine($"student Id={Id},Name={Name},Courses={string.Join(",", Courses)}");
        }

        public override void Load(Dictionary<string, string> data)
        {
            if (data.ContainsKey("id"))
                Id = int.Parse(data["id"]);
            if (data.ContainsKey("name"))
                Name = data["name"];
            if (data.ContainsKey("courses"))
                Courses = data["courses"].Split(',').Select(int.Parse).ToList();
        }
    }

    public class Teacher : Creator
    {
        public int Experience { get; set; }
        public List<int> Courses { get; set; } = new List<int>();

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine($"teacher Id={Id},Name={Name},Exp={Experience},Courses={string.Join(",", Courses)}");
        }

        public override void Load(Dictionary<string, string> data)
        {
            if (data.ContainsKey("id"))
                Id = int.Parse(data["id"]);
            if (data.ContainsKey("name"))
                Name = data["name"];
            if (data.ContainsKey("exp"))
                Experience = int.Parse(data["exp"]);
            if (data.ContainsKey("courses"))
                Courses = data["courses"].Split(',').Select(int.Parse).ToList();
        }
    }

    public class Course : Creator
    {
        public int TeacherId { get; set; }
        public List<int> Students { get; set; } = new List<int>();

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine($"course Id={Id},Name={Name},TeacherId={TeacherId},Students={string.Join(",", Students)}");
        }

        public override void Load(Dictionary<string, string> data)
        {
            if (data.ContainsKey("id"))
                Id = int.Parse(data["id"]);
            if (data.ContainsKey("name"))
                Name = data["name"];
            if (data.ContainsKey("teacherid"))
                TeacherId = int.Parse(data["teacherid"]);
            if (data.ContainsKey("students"))
                Students = data["students"].Split(',').Select(int.Parse).ToList();
        }
    }
    public class CreatorFactory
    {
        public static Creator Create(string type)
        {
            switch (type.ToLower())
            {
                case "student":
                    return new Student();
                case "teacher":
                    return new Teacher();
                case "course":
                    return new Course();
                default:
                    throw new ArgumentException("Unknown type");
            }
        }
    }
    public class DataManager
    {
        public static void Save(string fileName, List<Creator> creators)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var creator in creators)
                {
                    creator.Save(writer);
                }
            }
        }

        public static List<Creator> Load(string fileName)
        {
            List<Creator> creators = new List<Creator>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // разделяем строку на тип и данные
                    var typeEndIndex = line.IndexOf(' ');
                    if (typeEndIndex == -1)
                        continue;

                    var type = line.Substring(0, typeEndIndex).ToLower();
                    var dataPart = line.Substring(typeEndIndex + 1);

                    //  пары ключ-значение
                    var keyValuePairs = dataPart.Split(',')
                                                .Select(part => part.Split('='))
                                                .Where(kv => kv.Length == 2)
                                                .ToDictionary(kv => kv[0].Trim().ToLower().Replace(" ", ""), kv => kv[1].Trim());

                    // создаём  через фабрику и загружаем
                    Creator creator = CreatorFactory.Create(type);
                    creator.Load(keyValuePairs);
                    creators.Add(creator);
                }
            }
            return creators;
        }
    }
}
