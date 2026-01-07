using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //캐릭터 스탯 계산
            //int baseAttack = 50;
            //int weaponDamage = 30;
            //int totalAttack = baseAttack + weaponDamage;

            //Console.WriteLine("=== 공격력 계산 ===");
            //Console.WriteLine($"기본 공격력 : {baseAttack}"); 
            //Console.WriteLine($"무기 공격력 : {weaponDamage}");
            //Console.WriteLine($"총 공격력 : {totalAttack}");

            ////데미지 계산
            //int playerHealth = 100;
            //int damage = 25;
            //playerHealth = playerHealth - damage;

            //Console.WriteLine("\n=== 데미지 계산 ===");
            //Console.WriteLine($"받은 데미지: {damage}");
            //Console.WriteLine($"남은 체력: {playerHealth}");

            ////경험치 계산
            //int monsterskilled = 5;
            //int expPerMonster = 100;
            //int totalExp = monsterskilled * expPerMonster;

            //Console.WriteLine("\n=== 경험치 계산 ===");
            //Console.WriteLine($"처치한 몬스터: {monsterskilled}마리");
            //Console.WriteLine($"몬스터당 경험치: {expPerMonster}");
            //Console.WriteLine($"총 경험치: {totalExp}\n");

            //아이템 분배
            //int totalGold = 1000;
            //int playerCount = 4;
            //int goldPerPlayer = totalGold / playerCount;
            //int remainderGold = totalGold % playerCount;

            //Console.WriteLine("\n=== 아이템 분배 ===");
            //Console.WriteLine($"총 골드: {totalGold}G");
            //Console.WriteLine($"플레이어 수: {playerCount}명");
            //Console.WriteLine($"플레이어당 골드: {goldPerPlayer}G");
            //Console.WriteLine($"남은 골드: {remainderGold}G");

            //증감연산자 ++ --

            //int b = 3;
            //b++; //후위 증가
            //Console.WriteLine(b);

            //--b; //전위 감소
            //Console.WriteLine(b);   

            //전위 후위 증가 중요
            //int count = 5;


            //Console.WriteLine(count++);
            //Console.WriteLine(count);


            //int killCount = 0;
            //int useBullets = 30;
            //int count = 3;

            //Console.WriteLine("=== 몬스터 처치 ===");
            //Console.WriteLine($"고블린 처치! (킬 카운트 : {++killCount})");
            //Console.WriteLine($"오크 처치! (킬 카운트 : {++killCount})");
            //Console.WriteLine($"드래곤 처치! (킬 카운트 : {++killCount})");
            //Console.WriteLine($"총 처치 수 : {killCount}마리");

            //Console.WriteLine("\n=== 사격 ===");
            //Console.WriteLine($"남은 탄약 : {useBullets})");
            //Console.WriteLine($"발사! 남은 탄약 : {--useBullets}");
            //Console.WriteLine($"발사! 남은 탄약 : {--useBullets}");
            //Console.WriteLine($"발사! 남은 탄약 : {--useBullets}");

            //Console.WriteLine("\n=== 카운트다운 ===");
            //Console.WriteLine(count--);
            //Console.WriteLine(count--);
            //Console.WriteLine(count--);
            //Console.WriteLine("발사!");

            //int x = 5;
            //int y = 10;

            //Console.WriteLine(x < y); 
            //Console.WriteLine(x > y);
            //Console.WriteLine(x <= y);
            //Console.WriteLine(x >= y);
            //Console.WriteLine(x == y); //같냐? f
            //Console.WriteLine(x != y); //다르냐? t

            //AND
            //bool a = true;
            //bool b = true;

            //Console.WriteLine(a && b);
            //a = false;
            //b = true;
            //Console.WriteLine(a && b);
            //a = true;
            //b = false;
            //Console.WriteLine(a && b);
            //a = false;
            //b = false;
            //Console.WriteLine(a && b);

            //OR
            //bool a = false, b = false;
            //Console.WriteLine(a || b);
            //a = false; b = true;
            //Console.WriteLine(a || b);
            //a = true; b = false;
            //Console.WriteLine(a || b);
            //a = true; b = true;
            //Console.WriteLine(a || b);

            //!
            //bool a = false;
            //Console.WriteLine(!a);

            //int x = 5; //0101
            //int y = 3; //0011

            //string binary = Convert.ToString(x & y, 2);
            //Console.WriteLine($"8비트 : {binary.PadLeft(8, '0')}");

            //binary = Convert.ToString(x | y, 2);
            //Console.WriteLine($"8비트 : {binary.PadLeft(8, '0')}");

            //binary = Convert.ToString(x ^ y, 2);
            //Console.WriteLine($"8비트 : {binary.PadLeft(8, '0')}");

            //binary = Convert.ToString(~x, 2);
            //Console.WriteLine($"8비트 : {binary.PadLeft(8, '0')}");

            //int value = 4; //0100

            //string binary = Convert.ToString(value<<1, 2);
            //// << >>
            //Console.WriteLine($"8비트 : {binary.PadLeft(8, '0')}");
            //binary = Convert.ToString(value >> 1, 2);
            //// << >>
            //Console.WriteLine($"8비트 : {binary.PadLeft(8, '0')}");

            int inventory = 0; //0000 0000

            Console.WriteLine($"초기 인벤토리 : {Convert.ToString(inventory, 2).PadLeft(8, '0')}");

            //슬롯 번호
            int slot1 = 0; //활
            int slot2 = 1; //지팡이

            //슬롯 0에 활을 추가
            inventory = inventory | (1 << slot1);
            Console.WriteLine($"슬롯 {slot1}에 활 추가");
            Console.WriteLine($"인벤토리 : {Convert.ToString(inventory, 2).PadLeft(8, '0')}");

            //슬롯 0에 활을 추가
            inventory = inventory | (1 << slot2);
            Console.WriteLine($"슬롯 {slot2}에 지팡이 추가");
            Console.WriteLine($"인벤토리 : {Convert.ToString(inventory, 2).PadLeft(8, '0')}");














        }
    }
}
