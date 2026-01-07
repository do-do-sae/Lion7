using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //랜덤 함수
            //게임에서 굉장히 중요한 기능이다.

            //Random 객체 생성
            //Random random = new Random(); //랜덤함수 사용방법

            ////사용방법
            //int number = random.Next(1, 7); //1~6까지 주사위
            //Console.WriteLine(number);

            //검 종류
            //무한의 대검   10%
            //카타나        20%
            //엑스칼리버    30%
            //정기정검      40%

            string sword = "";
          
            Random rand = new Random();
            int random = 0;
            
            Console.WriteLine("당신은 20번 뽑기가 가능합니다. 지금 실행합니다.");

            for(int i = 0; i < 20; i++)
            {
                random = rand.Next(1, 101);
                if (random >= 1 && random <= 10)
                {
                    sword = "무한의 대검";
                }
                else if (random >= 11 && random <= 30)
                {
                    sword = "카타나";
                }
                else if (random >= 31 && random <= 60)
                {
                    sword = "엑스칼리버";
                }
                else if (random >= 61 && random <= 101)
                {
                    sword = "정기정검";
                }

                Console.WriteLine(sword);
                Thread.Sleep(500);
            }




        }
    }
}
