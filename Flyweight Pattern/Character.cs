using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight_Pattern
{
    public class Character
    {
        string name;
        int tip;
        string img;
        int level;
        public Character(string name, int tip, string img, int level) 
        {
            this.name = name;
            this.tip = tip;
            this.img = img;
            this.level = level;
        }
        public void LevelNew()
        {
            this.level++;
        }
        public string toString()
        {  
            string s = name+" " + tip.ToString()+" "+img+" "+level.ToString();
            return s; 
        }
    }
    public class CharacterFactory
    {
        Hashtable hash = new Hashtable
        {
            {"one1", new Character("one", 1, "G:/home/one1.img",0)},
            {"one2", new Character("one", 2, "G:/home/one2.img",0)}
        };
        public Character NewLewel(string name, int tip)
        {
            string key = name + tip.ToString();
            (hash[key] as Character).LevelNew();
            return hash[key] as Character;
        }
        public Character GetFyweight(string name, int tip, string img)
        {
            string key = name + tip.ToString();
            if (!hash.ContainsKey(key))
                hash.Add(key, new Character(name,tip,img,0));
            return hash[key] as Character;
        }
    }
}
