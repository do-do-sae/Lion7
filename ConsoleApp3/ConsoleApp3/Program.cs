using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    //변수 선언 후 값 저장
            //    string greeting; //문자열 변수를 선언
            //    greeting = "안녕하세요~!"; //변수에 값 저장

            //    //출력하기
            //    Console.WriteLine(greeting);


            //변수 초기화
            //int score = 100; //정수형 변수 선언과 동시에 100으로 초기화
            //double temperature = 36.5; //실수형 변수 선언과 동시에 36.5로 초기화
            //string city = "Seoul"; //문자열 변수 선언과 동시에 "Seoul"로 초기화

            ////변수
            //Console.WriteLine("Score: " + score);
            //Console.WriteLine("Temperature: " + temperature);
            //Console.WriteLine("City: " + city);

            //방법1: 선언 후 할당 ( 두 줄 )
            int health;
            health = 100;

            //방법2: 선언과 동시에 할당 ( 한 줄 )
            int maxHealth = 100;
            int damage = 15;

            //게임로직 출력
            Console.WriteLine("현재 체력: " + health + "/" + maxHealth);
            Console.WriteLine("적의 공격! " + damage + " 데미지를 입었습니다.");
            health = health - damage;
            Console.WriteLine("남은 체력: " + health);
        }
    }
}
