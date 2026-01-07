using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for(int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("천마연산신공");
            //}

            //Console.Write("생성할 고블린 수를 입력하세요 : ");
            //int goblin = int.Parse(Console.ReadLine());
            //Console.WriteLine("=== 몬스터 웨이브 시작 ===");
            //for (int i = 1; i <= goblin; i++)
            //{
            //    Console.WriteLine($"고블린 #{i} 생성!");
            //}
            //Console.WriteLine($"총 {goblin}마리 생성 완료!");

            Console.WriteLine("=== 게임 시작 카운트다운 ===");
            for (int i = 5; i >= 0; i--)
            {
                if (i >= 1)
                {
                    Console.WriteLine($"{i}...");
                    Thread.Sleep(300);
                }
                else if (i == 0)
                {
                    Console.WriteLine("게임 시작!");
                }
            }



        }
    }
}
