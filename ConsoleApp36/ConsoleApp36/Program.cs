using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    internal class Program
    {
        //int 넘겨보기
        //static void Attack(int att, int def)
        //{
        //    Console.WriteLine("공격력 전달받았다 : " + att);    
        //    Console.WriteLine("방어력 전달받았다 : " + def);
        //}
        
        //함수로 만들기
        //플레이어이름 :
        //공격력 :
        //방어력 :
        //민첩   :
        //운     :

        static void playerStats(string name, int att, int def, int dex, int luk)
        {
            Console.WriteLine("플레이어이름   :" + name);
            Console.WriteLine("공격력         :"  + att);
            Console.WriteLine("방어력         :"  + def);
            Console.WriteLine("민첩           :"  + dex);
            Console.WriteLine("운             :"  + luk);
        }

        static void Main(string[] args)
        {
            playerStats("홍길동", 100, 30, 60, 20);
        }
    }
}
