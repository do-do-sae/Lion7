using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string 형식: 여러 문자를 저장
            //string greeting = "Hello, World!"; //문자열 저장
            //string name = "Alice"; //이름 저장

            //Console.WriteLine(greeting);
            //Console.WriteLine(name);

            //문자(char) - 단 하나의 문자만
            char grade = 'A';
            char symbol = '★';
            //char number = '9'; // 문자 '9'이지 숫자 9가 아님!

            // 문자열 (string) - 여러 문자의 조합
            string playerName = "홍길동";
            string welcomeMessage = "게임에 오신 것을 환영합니다!";
            //string emptyString = ""; // 빈 문자열도 가능

            Console.WriteLine("**실행 결과: **");
            Console.WriteLine("=== RPG 게임 ===");
            Console.WriteLine($"플레이어: {playerName}");
            Console.WriteLine($"등급: {grade}등급 {symbol}");
            Console.WriteLine($"{welcomeMessage}");
        }
    }
}
