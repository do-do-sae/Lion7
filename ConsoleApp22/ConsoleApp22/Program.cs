using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int day = 3;

            //switch(day)
            //{
            //    case 1:
            //        Console.WriteLine("월요일");
            //        break;
            //    case 2:
            //        Console.WriteLine("화요일");
            //        break;
            //    case 3:
            //        Console.WriteLine("수요일");
            //        break;
            //    default:
            //        Console.WriteLine("유효하지 않은 요일");
            //        break;
            //}

            //캐릭터 선택 화면을 switch로 만드시오
            //jobChice = 1; // 전사 2: 마법사 3: 궁수 4: 도적
            Console.WriteLine("=== 캐릭터 생성 ===");
            Console.WriteLine("1. 전사 2. 마법사 3. 궁수 4. 도적");
            Console.Write("원하는 직업을 선택하시오 : ");
            int jobChice = int.Parse(Console.ReadLine());

            switch (jobChice)
            {
                case 1:
                    Console.WriteLine("\n직업 : 전사\n특성 : 강력한 물리 공격\n주 무기: 검, 도끼\n스탯: 체력 + 100, 물리 공격 + 20");
                    break;
                case 2:
                    Console.WriteLine("\n직업 : 마법사\n특성 : 강력한 마법 공격\n주 무기: 지팡이, 마법서\n스탯: 마나 + 100, 마법력 + 20");
                    break;
                case 3:
                    Console.WriteLine("\n직업 : 궁수\n특성 : 강력한 원거리 공격\n주 무기: 활, 석궁\n스탯: 공격 속도 + 100, 원거리 공격 + 20");
                    break;
                case 4:
                    Console.WriteLine("\n직업 : 도적\n특성 : 폭발적인 순간 공격\n주 무기: 단도, 수리검\n스탯: 이동 속도 + 100, 행운 + 20");
                    break;
                default:
                    Console.WriteLine("❌ 잘못된 선택입니다.");
                    Console.WriteLine("1~4 중에서 선택해주세요.");
                    break;
            }
        }
    }
}
