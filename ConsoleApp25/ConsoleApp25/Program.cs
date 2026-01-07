using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //문제 1 : 온도에 따른 옷차림 추천
            Console.Write("온도를 입력하세요 : ");
            int todayTemp = int.Parse(Console.ReadLine());
            Console.WriteLine($"현재 온도 : {todayTemp}°C");
            if (todayTemp >= 30)
            {
                Console.WriteLine("매우 더워요! 반팔과 반바지를 입으세요.");
            }
            else if (todayTemp >= 20)
            {
                Console.WriteLine("적당해요! 긴팔 티셔츠를 입으세요.");
            }
            else if (todayTemp >= 10)
            {
                Console.WriteLine("쌀쌀해요! 가디건이나 자켓을 챙기세요.");
            }
            else if (todayTemp >= 0)
            {
                Console.WriteLine("추워요! 코트를 입으세요.");
            }
            else if (todayTemp <= 0)
            {
                Console.WriteLine("매우 추워요! 패딩과 목도리가 필요해요");
            }

            //문제 2 : 게임 캐릭터 직업 선택
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("\n\n직업 선택 ( 1. 전사 2. 마법사 3. 궁수 4. 도적 ) : ");
            int jobChice = int.Parse(Console.ReadLine());
            Console.WriteLine("\n=== 캐릭터 생성 ===");

            switch (jobChice)
            {
                case 1:
                    Console.WriteLine("\n⚔️전사 - 강력한 물리 공격\n시작 스탯 : HP + 50, 공격력 + 10");
                    break;
                case 2:
                    Console.WriteLine("\n🔮마법사 - 강력한 마법 공격\n시작 스탯 : 마나 + 100, 마법력 + 20");
                    break;
                case 3:
                    Console.WriteLine("\n🏹궁수 - 원거리 공격 특화\n시작 스탯 : 민첩 + 15, 크리티컬 + 10%");
                    break;
                case 4:
                    Console.WriteLine("\n🗡️도적 - 빠른 속도와 회피\n시작 스탯 : 민첩 + 20, 회피율 +15%");
                    break;
                default:
                    Console.WriteLine("❌ 잘못된 선택입니다.");
                    Console.WriteLine("1~4 중에서 선택해주세요.");
                    break;
            }
        }
    }
}
