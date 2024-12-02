using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern
{
    interface IWeapon
    {
        void UseWeapon();
    }
    internal class Sword : IWeapon
    {
        public void UseWeapon() 
        {
            Console.WriteLine("Это меч");
        }
    }
    internal class Bow : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Это лук");
        }
    }
    internal class Axe : IWeapon
    {
        public void UseWeapon()
        {
            Console.WriteLine("Это топор");
        }
    }
    internal class Player
    {
        IWeapon weapon;
        internal void SetWeapon(IWeapon weapon)
        { this.weapon = weapon; }
        internal void Attack()
        { weapon.UseWeapon(); }
    }
    internal class Game
    {
        Player player = new Player();
        internal void WeaponNew(IWeapon weapon)
        {
            player.SetWeapon(weapon);
        }
        internal void WeaponUse()
        {
            player.Attack();
        }
        internal void Start()
        {
            IWeapon bowone = new Bow();
            WeaponNew(bowone);
            string s = "";
            while (s != "stop")
            {
                Console.WriteLine("Сменим оружие? 1 - да, 2 - нет");
                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Console.WriteLine("Выберите оружие: 1 - лук, 2 - меч, 3 - топор");
                        s = Console.ReadLine();
                        switch (s)
                        {
                            case "1":
                                IWeapon bow = new Bow();
                                WeaponNew(bow);
                                break;
                            case "2":
                                IWeapon sword = new Sword();
                                WeaponNew(sword);
                                break;
                            case "3":
                                IWeapon axe = new Axe();
                                WeaponNew(axe);
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("будем использовать оружие? 1 - да, 2 - нет");
                        if (Console.ReadLine() == "1")
                            WeaponUse();
                        break;
                    case "2":
                        Console.WriteLine("будем использовать оружие? 1 - да, 2 - нет");
                        if (Console.ReadLine() == "1")
                            WeaponUse();
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Game Over");
        }
    }
}
