using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool 형식 : 참(true) 또는 거짓(false)
            bool isRunning = true;
            bool Pause = false;
            bool KEY = false;
            bool DoorOpen = false;
            bool PlayerAlive = true;
            bool PlayerHealth = true;
            bool PlayerDanger = false;
            //bool isFinished = false;

            int Health = 80;
            //Console.WriteLine(isRunning);
            //Console.WriteLine(isFinished);

            //실전예제
            Console.WriteLine("=== 게임 상태 ===");
            Console.WriteLine($"게임 실행 중: {isRunning}");
            Console.WriteLine($"일시정지: {Pause}");
            Console.WriteLine($"열쇠 소지: {KEY}");
            Console.WriteLine($"문 열림: {DoorOpen}");
            Console.WriteLine($"플레이어 생존: {PlayerAlive} \n");

            Console.WriteLine("=== 캐릭터 상태 ===");
            Console.WriteLine($"체력: {Health}");
            Console.WriteLine($"건강 상태: {PlayerHealth}");
            Console.WriteLine($"위험 상태: {PlayerDanger}");


            // 아이템 소지 여부
            bool hasWeapon = true;
            bool hasArmor = false;
            bool hasPotion = true;

            Console.WriteLine("\n=== 인벤토리 ===");
            Console.WriteLine($"무기 보유: {(hasWeapon ? "있음" : "없음")}");
            Console.WriteLine($"방어구 보유: {(hasArmor ? "있음" : "없음")}");
            Console.WriteLine($"포션 보유: {(hasPotion ? "있음" : "없음")}");

        }
    }
}
