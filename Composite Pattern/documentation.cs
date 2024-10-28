using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    /*public interface IDocumentComponent
    {
        void Add(Component component);
        void Remove(Component component);
        void Display();
    }*/

    public abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public abstract string Display();
        public abstract void Add(Component component);
        public abstract void Add(Component whereComponent, Component component);
        public abstract void Remove(Component component);
    }

    public class Paragraph : Component
    {
        public Paragraph(string name) : base(name) { }
        public override string Display() // возвращает параграф
        {
            return name;
        }
        public override void Add(Component component) 
        {
            throw new NotImplementedException();
        }
        public override void Add(Component whereComponent, Component component)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Component component) 
        {
            throw new NotImplementedException();
        }
    }
    public class Section : Component
    {
        public List<Component> components = new List<Component>();
        public Section(string name) : base(name) { }
        public override string Display() // возвращает содержание раздела
        {
            string s = name+"\n";
            foreach (var comp in components)
            {
                s+=comp.Display();
                s += "\n";
            }
            return s;
        }
        public override void Add(Component component) // добавляет элемент в раздел
        {
            components.Add(component);
        }
        public override void Add(Component whereComponent, Component component) // доавляет абзац в раздел
        {

            components[components.IndexOf(whereComponent)].Add(component);
        }
        public override void Remove(Component component) // удаляет элемент из раздела
        {
            components.Remove(component);
        }
    }

    public class Document
    {
        public List<Component> components = new List<Component>();
        private string name;
        public Document(string name)
        {
            this.name = name;
        }
        public string Display() // возвращает содержание документа
        {
            string s = name+"\n";
            foreach (var comp in components)
            {
                s += comp.Display();
                s += "\n";
            }
            return s;
        }
        public void Add(Component component) // добавляет раздел в документ
        {
            if (component is Section)
            {
                components.Add(component);
            }
            else 
            {
                Console.WriteLine("Это не раздел. Это нельзя добавить");
            }
        }
        public void Add(Component whereComponent, Component component) // доавляет раздел в раздел
        {

            components[components.IndexOf(whereComponent)].Add(component);
        }
        public void Remove(Component component) // удаляет раздел из документа
        {
            try
            {
                components.Remove(component);
            }
            catch
            {
                Console.WriteLine("укажите в каком раздеде этот раздел");
            }
        }
        public void Remove(Component whereComponent, Component component) // удаляет раздел из раздела
        {
            components[components.IndexOf(whereComponent)].Remove(component);
        }
    }
}
