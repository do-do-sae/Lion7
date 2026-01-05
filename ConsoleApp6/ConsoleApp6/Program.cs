using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////상수 : 값을 변경할 수 없는 변수
            //const double Pi = 3.14159; //상수 Pi 선언 및 초기화
            //const int MaxScore = 100; //정수형 상수 선언

            ////출력
            //Console.WriteLine("Pi: " + Pi);
            //Console.WriteLine("MaxScore: " + MaxScore);


            const int MaxPlayers = 4;
            const int StartGold = 1000;
            const string version = "1.0.0";

            Console.WriteLine("**실행 결과: **");
            Console.WriteLine("'''");
            Console.WriteLine("=== 게임 설정 ===");
            Console.WriteLine($"최대 플레이어: {MaxPlayers}명");
            Console.WriteLine($"시작 골드: {StartGold}G");
            Console.WriteLine($"버전: {version}");
            Console.WriteLine("'''");


        }
    }
}
