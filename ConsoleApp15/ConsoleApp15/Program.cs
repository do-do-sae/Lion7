using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. 암시적 변환 (작은 타입 -> 큰 타입)
            int smallNumber = 100;
            long bigNumber = smallNumber; //int -> long(자동 변환)
            double doubleNumber = smallNumber; //int -> double(자동 변환)

            Console.WriteLine("=== 암시적 변환 ===");
            Console.WriteLine($"int: {smallNumber.GetType()}");
            Console.WriteLine($"long: {bigNumber.GetType()}");
            Console.WriteLine($"double: {doubleNumber.GetType()}");

            //2. 명시적 변환 (큰 타입 -> 작은 타입)
            double pi = 3.14159;
            int intPi = (int)pi; //double -> int(명시적 변환) 소수점을 버림

            Console.WriteLine($"\n=== 명시적 변환 ===");
            Console.WriteLine($"double: {pi}");
            Console.WriteLine($"int로 변환: {intPi}");

            //3. 문자열을 숫자로 변환
            string scoreText = "95";
            int score = int.Parse(scoreText); //문자열 -> 정수

            string priceText = "19.99";
            double price = double.Parse(priceText); //문자열 -> 실수

            Console.WriteLine("\n=== 문자열 변환 ===");
            Console.WriteLine($"점수(문자열) : {scoreText} -> 숫자 : {score}");
            Console.WriteLine($"점수(문자열) : {priceText} -> 숫자 : {price}");

            //4. 숫자를 문자열로 변환
            int playerLevel = 50;
            string levelText = playerLevel.ToString();

            Console.WriteLine("\n=== 숫자를 문자열로 변환 ===");
            Console.WriteLine($"레벨(숫자): {playerLevel} -> 문자열 : {levelText}");



        }
    }
}
