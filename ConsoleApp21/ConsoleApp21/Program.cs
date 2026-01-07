using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("점수를 입력하세요 : ");
            //int a = int.Parse(Console.ReadLine());

            //if (a >= 90)
            //{
            //    Console.WriteLine("A등급");
            //}
            //else if (89 >= a && a >= 80)
            //{
            //    Console.WriteLine("B등급");
            //}
            //else if (79 >= a && a >= 70)
            //{
            //    Console.WriteLine("C등급");
            //}
            //else
            //{
            //    Console.WriteLine("D등급");
            //}


            // HP
            //Console.OutputEncoding = Encoding.UTF8;

            //Console.Write("HP를 입력하세요 : ");
            //int playerHp = int.Parse(Console.ReadLine());
            //int maxHp = 100;
            //int enemyDistance = 3;
            //int attackRange = 5;



            //Console.WriteLine($"현재 체력 : {playerHp}/{maxHp}");
            //if (playerHp <= maxHp * 0.3)
            //{
            //    Console.WriteLine("⚠️ 경고: 체력이 위험합니다!");
            //    Console.WriteLine("회복 아이템을 사용하세요!");
            //}
            //if (playerHp <= maxHp * 0.5)
            //{
            //    Console.WriteLine("💊 체력이 50% 이하입니다.");
            //}
            //if (playerHp == 0)
            //{
            //    Console.WriteLine("💀 게임 오버!");
            //    Console.WriteLine("부활 지점에서 다시 시작합니다.");
            //}
            //// 거리
            //if (attackRange >= enemyDistance)
            //{
            //    Console.WriteLine("\n⚔️ 적이 사거리 안에 있습니다!");
            //    Console.WriteLine("공격 가능!");
            //}


            //아이템 구매 시스템
            //int playerGold = 500;
            //int itemPrice = 250;
            //string itemName = "강철 검";

            //Console.WriteLine("=== 상 점 ===");
            //Console.WriteLine($"아이템 : {itemName}");
            //Console.WriteLine($"가격 : {itemPrice}G");
            //Console.WriteLine($"소지금 : {playerGold}G");
            //Console.WriteLine();

            //if (playerGold > itemPrice)
            //{
            //    //구매 가능
            //    playerGold = itemPrice;
            //    Console.WriteLine("구매 성공!");
            //    Console.WriteLine($"{itemName}을 획득했습니다.");
            //    Console.WriteLine($"남은 골드: {playerGold}");
            //}
            //else
            //{
            //    //구매 불가
            //    int needGold = itemPrice - playerGold;
            //    Console.WriteLine("골드가 부족합니다!");
            //    Console.WriteLine($"필요한 골드 : {needGold}골드 더 필요");
            //}

            //Console.WriteLine("\n=== 던전 입장 ===");
            //int playerLevel = 48;
            //int requiredLevel = 50;

            //if (playerLevel >= requiredLevel)
            //{
            //    Console.WriteLine("던전에 입장합니다!");
            //    Console.WriteLine("전투 준비!");
            //}
            //else
            //{
            //    Console.WriteLine("레벨이 부족합니다!");
            //    Console.WriteLine($"필요 레벨 : {requiredLevel}");
            //    Console.WriteLine($"현재 레벨 : {playerLevel}");
            //    Console.WriteLine($"레벨업이 필요합니다 : {requiredLevel - playerLevel}레벨");

            //}

            //점수에 따른 등급 판정
            //int score = 8500;
            //string rank;

            //Console.WriteLine("=== 게임 랭크 시스템 ===");
            //Console.WriteLine("스코어를 입력하세요 : ");
            //score = int.Parse(Console.ReadLine());
            //Console.WriteLine($"점수 : {score}");

            //if (score >= 10000)
            //{
            //    rank = "SSS";
            //    Console.WriteLine($"등급 : {rank} (레전드)");
            //    Console.WriteLine("보상: 전설 아이템 + 골드 10000");
            //}
            //else if (score >= 8000)
            //{
            //    rank = "SS";
            //    Console.WriteLine($"등급 : {rank} (마스터)");
            //    Console.WriteLine("보상: 영웅 아이템 + 골드 5000");
            //}
            //else if (score >= 6000)
            //{
            //    rank = "S";
            //    Console.WriteLine($"등급 : {rank} (다이아)");
            //    Console.WriteLine("보상: 희귀 아이템 + 골드 3000");
            //}
            //else if (score >= 4000)
            //{
            //    rank = "A";
            //    Console.WriteLine($"등급 : {rank} (플래티넘)");
            //    Console.WriteLine("보상: 고급 아이템 + 골드 1500");
            //}
            //else
            //{
            //    rank = "B";
            //    Console.WriteLine($"등급 : {rank} (골드)");
            //    Console.WriteLine("보상: 일반 아이템 + 골드 500");
            //}

            // 캐릭터 상태 판정
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("\n=== 캐릭터 상태 ===");
            Console.Write("체력을 입력해보세요 : ");
            int health = int.Parse(Console.ReadLine());

            if (health >= 80)
            {
                Console.WriteLine("💚 상태: 매우 좋음");
            }
            else if (health >= 60)
            {
                Console.WriteLine("🟢 상태: 좋음");
            }
            else if (health >= 40)
            {
                Console.WriteLine("🟡 상태: 보통");
            }
            else if (health >= 20)
            {
                Console.WriteLine("🟠 상태: 위험");
            }
            else if (health > 0)
            {
                Console.WriteLine("🔴 상태: 매우 위험!");
            }
            else if (health == 0)
            {
                Console.WriteLine("🔴 상태: 캐릭터 사망!");
            }


            
        }
    }
}
