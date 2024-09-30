using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class ComputerBuilder
    {
        public string name;
        public CPU cpu;
        public motherboard motherboard;
        public RAM ram;
        public storage storage;
        public videoCard videoCard;
        public ComputerBuilder(string s) 
        { 
            this.name = s;
        }
        public ComputerBuilder SetCPU(string s)
        {
            cpu = new CPU(s);
            this.cpu = cpu;
            return this;
        }
        public ComputerBuilder Setmotherboard(string s)
        {
            motherboard = new motherboard(s);
            this.motherboard=motherboard;
            return this;
        }
        public ComputerBuilder SetRAM(int v)
        {
            ram = new RAM(v);
            this.ram = ram;
            return this;
        }
        public ComputerBuilder Setstrorage(int v) 
        {
            storage = new storage(v);
            this.storage=storage;
            return this;
        }
        public ComputerBuilder SetvideoCard(string s)
        {
            videoCard = new videoCard(s);
            this.videoCard = videoCard;
            return this;
        }
        public Computer Build()
        {
            return new Computer(this);
        }
    }
}
