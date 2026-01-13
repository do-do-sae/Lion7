using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp40
{
    internal class Program
    {
        //기본매개변수 사용
        static void CastFireBall(string target, int damage = 100, int manaCost = 30)
        {
            Console.WriteLine($"파이어볼 시전!");
            Console.WriteLine($"대상: {target}");
            Console.WriteLine($"데미지: {damage}");
            Console.WriteLine($"마나 소모: {manaCost}");
        }

        //static void Main(string[] args)
        //{
        //    //모든매개변수 지정
        //    CastFireBall("고블린", 150, 40);
        //    Console.WriteLine();
        //    CastFireBall("오크", 20);
        //    Console.WriteLine();
        //    CastFireBall("드래곤");
        //    Console.WriteLine();
        //    CastFireBall("오우거", manaCost: 60);
        //}

        static void useItem(string itemName = "회복 포션", int itemS = 50)
        {
            Console.WriteLine($"{itemName} 사용!");
            Console.WriteLine($"회복량: {itemS} HP");
            Console.WriteLine();
        }

        static void monsterSummon(string monsterName, int monsterLevel = 1, int monsterCount = 1)
        {
            Console.WriteLine($"{monsterName} 소환!");
            Console.WriteLine($"레벨: {monsterLevel}");
            Console.WriteLine($"수량: {monsterCount}마리");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            useItem();
            useItem("고급 회복 포션", 100);
            monsterSummon("슬라임");
            monsterSummon("고블린", 5);
            monsterSummon("드래곤", 50, 3);
        }

    }
}

