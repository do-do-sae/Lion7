using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp44
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
            // Character character = new Character();
            // character.Render(); //캐릭터
            //Character character = new Warrior(); //업캐스팅   부모 <- 자식메모리 참조
            //character.Render();
            //Character character = new Mage();
            //character.Render();//마법사

            //Warrior warrior = new Mage();
            //warrior.Render();

            // Mage mage = new Mage();
            // mage.Render();

            Character character = new Warrior();  //업캐스팅

            Warrior warrior = (Warrior)character; //다운캐스팅

            warrior.Render();

        }
    }
}