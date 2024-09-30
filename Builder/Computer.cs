using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Computer
    {
        private string name;
        private CPU cpu;
        private motherboard motherboard;
        private RAM ram;
        private storage storage;
        private videoCard videoCard;
        public Computer(ComputerBuilder builder)
        {
            this.name = builder.name;
            this.cpu = builder.cpu;
            this.motherboard = builder.motherboard;
            this.ram = builder.ram;
            this.storage = builder.storage;
            this.videoCard = builder.videoCard;
        }
        public string GetDescription()
        {
            string s="Имя компьютера ";
            s += this.name + "\n" + this.cpu.String() + "\n" + this.motherboard.String() + "\n" + this.ram.String() + "\n" + this.storage.String() + "\n"  + this.videoCard.String();
            return s;
        }
    }
}
