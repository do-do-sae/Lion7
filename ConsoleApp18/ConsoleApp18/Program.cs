using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ===== 1번 문제 =====");
            int currentHP = 80;
            int maxHP = 100;
            int monsterDamage = 25;
            int potionHeal = 30;
            int poisonDamage = 5;

            Console.WriteLine($"초기 체력 : {currentHP}/{maxHP}");
            Console.WriteLine($"데미지 -25 : {currentHP -= monsterDamage}/{maxHP}");
            Console.WriteLine($"회복 +30 : {currentHP += potionHeal}/{maxHP}");
            Console.WriteLine($"독 데미지 -5 : {currentHP -= poisonDamage}/{maxHP}");

            Console.WriteLine("\n ===== 2번 문제 =====");
            int expPerMonster = 150;
            int monsterskilled = 3;
            int expForLevelUp = 500;

            Console.WriteLine($"처치한 몬스터 : {monsterskilled}마리");
            Console.WriteLine($"획득 경험치 : {expPerMonster * monsterskilled}");
            Console.WriteLine($"레벨업까지 필요 : {expForLevelUp - (expPerMonster * monsterskilled)}");

            Console.WriteLine("\n ===== 3번 문제 =====");
            int totalGold = 1234;
            int partyMembers = 5;
            Console.WriteLine($"총 골드 : {totalGold}G");
            Console.WriteLine($"파티원 : {partyMembers}명");
            Console.WriteLine($"1인당 골드 : {totalGold / partyMembers}G");
            Console.WriteLine($"남은 골드 : {totalGold % partyMembers}G");

            Console.WriteLine("\n ===== 4번 문제 =====");
            int playerLevel = 35;
            int requiredLevel = 30;
            bool hasKey = true;
            int currentHP2 = 60;
            int maxHP2 = 100;

            Console.WriteLine("=== 던전 입장 조건 ===");
            var levelKey = playerLevel >= requiredLevel;
            Console.WriteLine($"레벨 조건 : ({requiredLevel} 이상) : {levelKey}");
            Console.WriteLine($"열쇠 보유 : {hasKey}");
            var healthKey = currentHP2 >= (maxHP2 * 0.5);
            Console.WriteLine($"체력 조건 : (50% 이상) : {healthKey}");
            Console.WriteLine($"입장 가능 : {levelKey && hasKey && healthKey}");

            Console.WriteLine("\n ===== 5번 문제 =====");
            int originalPrice = 5000;
            bool isVIP = true;
            bool hasCoupon = true;
            double finalPrice = originalPrice;

            Console.WriteLine($"원가 : {originalPrice}G");
            if (isVIP)
            {
                finalPrice = finalPrice * 0.8;
                Console.WriteLine($"VIP 할인 (20%) : {finalPrice}G");
            }
            if (hasCoupon)
            {
                finalPrice -= 500;
                Console.WriteLine($"쿠폰 할인 (-500골드) : {finalPrice}G");
            }
            Console.WriteLine($"최종 가격 : {finalPrice}G");



        }
    }
}
