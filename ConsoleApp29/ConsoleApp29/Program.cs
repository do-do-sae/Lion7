using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const int targetX = 50;
            const int targetY = 20;

            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            int x = 10, y = 10;

            ConsoleKeyInfo keyInfo; // 키 관련된 정보

            Console.CursorVisible = false;

            while(true)
            {
                Console.Clear(); //화면 지우기

                Console.SetCursorPosition(x, y); //좌표

                Console.Write("●"); //현재 위치 출력

                Console.SetCursorPosition(targetX, targetY);
                Console.Write("🏠");

                if (x == targetX && y == targetY)
                {
                    Console.Clear();
                    Console.WriteLine("집에 도착했습니다.");

                    break;
                }





                keyInfo = Console.ReadKey(true); //키 입력 받기 (화면 출력 x)

                //방향키 입력에 따른 좌표 변경
                switch(keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: if (y > 0) y--; break;
                    case ConsoleKey.DownArrow: if (y < Console.WindowHeight -1) y++; break;
                    case ConsoleKey.LeftArrow: if (x > 0) x--; break;
                    case ConsoleKey.RightArrow: if (x < Console.WindowWidth -1) x++; break;
                    case ConsoleKey.Spacebar:   Console.Write("미사일키"); break;
                    case ConsoleKey.Escape: break; //ESC키로 탈출 
                }


            }


        }
    }
}
