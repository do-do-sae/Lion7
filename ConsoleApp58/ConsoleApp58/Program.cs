using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp58
{
    public class Character
    {
        public virtual void Render()
        {
            Console.WriteLine("캐릭터");
        }
    }
    public class Warrior : Character
    {
        public override void Render()
        {
            Console.WriteLine("워리어");
        }
    }
    public class Mage : Warrior
    {
        public override void Render()
        {
            Console.WriteLine("마법사");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Character character1 = new Character();
            //Character character2 = new Warrior(); //업캐스팅 부모<=자식메모리 참조
            //Character character3 = new Mage();
            //character1.Render();
            //character2.Render();
            //character3.Render();

            //Mage mage = new Mage();
            //mage.Render();
            Character character = new Warrior(); //업캐스팅
            //Warrior warrior = (Warrior)character; //다운캐스팅
            //warrior.Render();
            //is 연산자 문법
            //if (character is Warrior)
            //{
            //    Warrior warrior = (Warrior)character;
            //    warrior.Render();
            //}

            Warrior warrior = character as Warrior;
            if (warrior != null)
            {
                warrior.Render();
            }

        }
    }
}
