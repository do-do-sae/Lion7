using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int i = 0;
            //while(i < 5)
            //{
            //    Console.WriteLine(i);
            //    i++; //증감

            //Console.WriteLine("\n=== 예제 2: 카운트다운 ===");
            //int countDown = 10;

            //while (countDown > 0)
            //{
            //    Console.WriteLine(countDown);
            //    countDown--;
            //}

            //Console.WriteLine("\n=== 예제 3: 합계 구하기 ===");
            //int sum = 0;
            //int i = 1;
            //while (i < 5)
            //{
            //    sum +=  i;
            //    i++;
            //}
            //Console.WriteLine(sum);

            Console.WriteLine("\n=== 예제 4: 목표 달성하기 ===");
            int coins = 0;
            int target = 50;
            int day = 0;

            while (coins < target)
            {
                day++;
                coins += 10;
                Console.WriteLine($"{day}일차 : 코인 {coins}개");

            }
            Console.WriteLine($"목표 달성 : {day}일 걸렸습니다.");

            //int x = 5;
            //do
            //{
            //    Console.WriteLine("최소 한번 실행됩니다.");
            //    x--;
            //} while (x > 0);

            //string choice;
            //int totalPrice = 0;

            //do
            //{
            //    //메뉴 출력
            //    Console.WriteLine("메뉴판");
            //    Console.WriteLine("1. 짜장면 - 5,000원");
            //    Console.WriteLine("2. 짬뽕 - 6,000원");
            //    Console.WriteLine("3. 탕수육 - 15,000원");
            //    Console.WriteLine("4. 볶음밥 - 7,000원");
            //    Console.WriteLine("0. 주문 완료");
            //    Console.WriteLine("======================");
            //    Console.Write("\n메뉴 번호를 선택하세요: ");

            //    choice = Console.ReadLine();

            //    //메뉴 선택 처리
            //    switch (choice)
            //    {
            //        case "1":
            //            Console.WriteLine("\n짜장면 추가! (+5,000원)");
            //            totalPrice += 5000;
            //            break;
            //        case "2":
            //            Console.WriteLine("\n짬뽕 추가! (+6,000원)");
            //            totalPrice += 6000;
            //            break;
            //        case "3":
            //            Console.WriteLine("\n탕수육 추가! (+15,000원)");
            //            totalPrice += 15000;
            //            break;
            //        case "4":
            //            Console.WriteLine("\n볶음밥 추가! (+7,000원)");
            //            totalPrice += 7000;
            //            break;
            //        case "0":
            //            Console.WriteLine($"\n주문 완료 : {totalPrice}원");
            //            break;
            //        default:
            //            Console.WriteLine("\n잘못된 선택입니다.\n");
            //            break;
            //    }
            //    if (choice != "0")
            //    {
            //        Console.WriteLine($"현재 총액 : {totalPrice:N0}원\n");
            //    }

            //} while (choice != "0"); //0을 입력할 때까지 반복

            //for (int i = 0; i <= 10; i++)
            //{
            //    if (i == 5) 
            //        continue;
            //    Console.WriteLine(i);
            //}

            //    int n = 1;

            //천마귀환:
            //    Console.WriteLine("천마귀환.");

            //    if(n <= 5)
            //    {
            //        Console.WriteLine(n);
            //        n++;
            //        goto 천마귀환; //레이블로 이동
            //    }

            //천마강림:
            //Console.WriteLine("천마강림.");





        }
    }
}
