using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    abstract class Class1
    {
        internal int ID;
        internal string Name;
        internal List<int> IDs = new List< int>();
        internal Class1 (int id, string name)
        {
            ID = id;
            Name = name;
        }
        internal abstract void Add(int id);

    }
    class Student : Class1
    {
        internal List<Course> courseList = new List<Course>();
        public Student(int id, string name) : base(id, name)
        {
        }
        internal override void Add(int id)
        {
            IDs.Add(id);
        }
        internal void Cours(Course cours)
        {
            foreach (var elem in IDs)
            {
                if (cours.ID == elem)
                {
                    courseList.Add(cours);
                    break;
                }
            }
        }
    }
    class Teacher : Class1
    {
        internal List<Course> courseList = new List<Course>();
        internal int Experience;
        public Teacher(int id, string name, int eperience) : base(id, name)
        {
            Experience = eperience;
        }
        internal override void Add(int id)
        {
            IDs.Add(id);
        }
        internal void Cours(Course cours)
        {
            foreach (var elem in IDs)
            {
                if (cours.ID == elem)
                {
                    courseList.Add(cours);
                    break;
                }
            }
        }
    }
    class Course : Class1
    {
        internal int Teacher_id;
        internal List<Course> studentList = new List<Course>();
        public Course(int id, string name, int teacher_id) : base(id, name)
        {
            Teacher_id=teacher_id;
        }
        internal override void Add(int id)
        {
            IDs.Add(id);
        }
        internal void Cours(Course cours)
        {
            foreach (var elem in IDs)
            {
                if (cours.ID == elem)
                {
                    studentList.Add(cours);
                    break;
                }
            }
        }
    }
}
