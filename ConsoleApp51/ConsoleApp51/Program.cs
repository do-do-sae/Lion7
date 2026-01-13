using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp51
{
    class Player
    {
        private string name;
        private int gold;
        private int maxHP;

        public Player()
        {
            maxHP = 100;
        }
        //프로퍼티 : MaxHP(읽기 전용)
        public int MaxHP
        {
            get { return maxHP; }
            private set { maxHP = value; }
        }

        public string Name { get { return name; } set { name = value; } }
        public int Gold
        {
            get { return gold; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
                else
                {
                    gold = value;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Name = "홍길동";
            player.Gold = 1000;
            //player.MaxHP = 1000; //읽기전용이라 외부에서 값 변경 불가

            Console.WriteLine($"이름 : {player.Name}\n골드 : {player.Gold}");
        }
    }
}
