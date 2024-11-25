using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Pattern
{
    class ArithmeticUnit
    {
        public string Register { get; private set; }
        private List <int> numbers = new List <int> ();
        public void Run(char operationCode, string operand, int NewInt)
        {
            switch (operationCode)
            {
                case '+':
                    if (NewInt==-1)
                        Register += operand;
                    else
                    {
                        Register = Register.Insert(numbers[numbers.Count-1], operand);
                        numbers.RemoveAt(numbers.Count-1);
                    }

                    break;
                case '-':
                    if (Register.LastIndexOf(operand) > -1)
                    {
                        numbers.Add(Register.LastIndexOf(operand));
                        Register = Register.Replace(operand, "");
                    }
                    else
                        Console.WriteLine("Невозможно удалить текс, так как он отсутствует");
                    break;
            }
        }
    }
    abstract class Command
    {
        protected ArithmeticUnit unit;
        protected string operand;
        public abstract void Execute();
        public abstract void Undo();
    }

    class Add : Command
    {
        public Add(ArithmeticUnit unit, string operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('+', operand, -1);
        }
        public override void Undo()
        {
            unit.Run('-', operand, 0);
        }        
    }
    class Sub : Command
    {
        public Sub(ArithmeticUnit unit, string operand)
        {
            this.unit = unit;
            this.operand = operand;
        }
        public override void Execute()
        {
            unit.Run('-', operand, -1);
        }
        public override void Undo()
        {
            unit.Run('+', operand, 0);
        }
    }
    class ControlUnit
    {
        private List <Command> commands = new List <Command>();
        private int current = 0;
        public void StoreComand (Command command)
        {
            commands.Add (command);
        }
        public void ExecuteCommand()
        {
            commands[current].Execute();
            current++;
        }
        public void Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (current > 0)
                {
                    commands[--current].Undo();
                }
            }
        }
    }

    class Editor
    {
        ArithmeticUnit arithmeticUnit;
        ControlUnit controlUnit;
        public Editor()
        { 
            arithmeticUnit = new ArithmeticUnit();
            controlUnit = new ControlUnit();
        }
        private string Run(Command command)
        {
            controlUnit.StoreComand (command);
            controlUnit.ExecuteCommand();
            return arithmeticUnit.Register;
        }
        public string Add(string text)
        {
            return Run(new Add(arithmeticUnit, text));
        }
        public string Sub(string text)
        {
            return Run (new Sub(arithmeticUnit, text));
        }
        public string Undo(int levels)
        {
            controlUnit.Undo(levels);
            return arithmeticUnit.Register;
        }
    }
}
