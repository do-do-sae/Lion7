using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    internal class Program
    {
        //문제 1: 평균 계산 함수
        //정수 배열을 받아 평균을 반환하는 함수를 만드세요.
        static double Average(int[] num)
        {
            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];
            }
            return (double)sum / num.Length;
        }

        //문제 2: 등급 판별 함수
        //점수를 받아 A, B, C, D, F 등급을 반환하는 함수를 만드세요.
        static char Rank(float grades)
        {
            if (grades >= 90) return 'A';
            else if (grades >= 80) return 'B';
            else if (grades >= 70) return 'C';
            else if (grades >= 60) return 'D';
            else return 'F';
        }

        //문제 3: 소수 판별 함수
        //숫자를 받아 소수인지 판별하는 함수를 만드세요.
        static bool PrimeNum(int num)
        {
            if (num < 2) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;
            for (int i = 3; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        //문제 4: 경험치 시스템
        //현재 경험치와 획득 경험치를 받아
        //레벨업 여부와 새 경험치를 반환하는 함수를 만드세요. (out 사용)
        static bool Exp(out int nowExp, out int aExp, out int mExp)
        {
            nowExp = 50;
            aExp = 200;
            mExp = 100;
            int Level = 1;

            Console.WriteLine($"현재 경험치 : {Level}레벨 {nowExp}/{mExp}");
            Console.WriteLine($"{aExp}의 경험치 획득!");

            int totalExp = nowExp + aExp;
            bool isLevelUp = totalExp >= mExp;

            while (totalExp >= mExp)
            {
                totalExp -= mExp; // 경험치를 mExp만큼 소모하고
                Level++;    // 레벨을 올림
                Console.WriteLine($"레벨업!! 현재 {Level}레벨! 남은 경험치: {totalExp}/{mExp}");
            }

            if (!isLevelUp)
            {
                Console.WriteLine($"레벨업까지 {mExp - totalExp}경험치 남았습니다");
            }

            return isLevelUp;
        }

        //문제 5: 아이템 강화 시스템
        //강화 레벨에 따라 성공 확률이 달라지는
        //아이템 강화 시스템을 함수로 구현하세요.
        static void Upgrade(int currentLevel)
        {
            Console.WriteLine($"==== 5번 =====");
            Console.WriteLine($"현재 강화 레벨: + {currentLevel}");

            Random rand = new Random();
            int successRate = 100 - (currentLevel * 10);
            int dice = rand.Next(1, 101); 

            if (dice <= successRate)
            {
                Console.WriteLine($"성공! (확률: {successRate}%) -> 현재 레벨: +{currentLevel + 1}");
            }
            else
            {
                Console.WriteLine($"실패... (확률: {successRate}%) -> 레벨이 유지됩니다.");
            }
            Console.WriteLine("==============");
        }




        static void Main(string[] args)
        {
            //1번 출력
            int[] scores = { 10, 20, 30, 40 };
            Console.WriteLine("==== 1번 =====");
            Console.WriteLine($"숫자: {string.Join(", ", scores)}");
            Console.WriteLine($"평균값: {Average(scores)}");
            Console.WriteLine("==============");
            Console.WriteLine();
            //2번 출력
            int grade = 90;
            Console.WriteLine("==== 2번 =====");
            Console.WriteLine($"성적 점수: {grade}");
            Console.WriteLine($"등급: {Rank(grade)}");
            Console.WriteLine("==============");
            Console.WriteLine();
            //3번 출력
            int num = 2;
            Console.WriteLine("==== 3번 =====");
            Console.WriteLine($"입력 숫자: {num}");
            Console.WriteLine($"소수인가요? : {(PrimeNum(num))}");
            Console.WriteLine("==============");
            Console.WriteLine();
            //4번 출력
            int nowExp;
            int aExp;
            int mExp;
            Console.WriteLine("==== 4번 =====");
            Exp(out nowExp, out aExp, out mExp);
            Console.WriteLine("==============");
            Console.WriteLine();
            //5번 출력
            Upgrade(3);
            Upgrade(5);
        }
    }
}
