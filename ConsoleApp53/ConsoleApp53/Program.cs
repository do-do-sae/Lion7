using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp53
{
    internal class Program
    {
        class Character
        {
            //static: 모든 캐릭터가 공유
            public static int totalCount = 0;

            //일반 : 각 캐릭터마다 다름
            public string name;

            public void AddCount()
            {
                totalCount++;
            }
        }
        static void Main(string[] args)
        {
            Character c1 = new Character();
            Character c2 = new Character();

            c1.name = "전사";
            c2.name = "마법사";

            Character.totalCount = 1;

            Console.WriteLine(c1.name);
            Console.WriteLine(c2.name);

            c1.AddCount();
            c2.AddCount();

            Console.WriteLine("카운트 : " + Character.totalCount);
        }
    }
}
