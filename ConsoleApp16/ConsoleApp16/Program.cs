using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //연산자
            //int a = 5, b = 3;
            //int sum = a + b; //산술연산자 사용 + 
            //bool isEqual = (a == b); //관계형 연산자 사용 ==

            //Console.WriteLine($"합 : {sum}");
            //Console.WriteLine($"a와 b가 같은가? : {isEqual}");

            //단항 연산자
            //int number = 5;
            //Console.WriteLine(+number);
            //Console.WriteLine(-number);

            //bool flag = true;
            //Console.WriteLine(!flag); // ! 논리 부정 : 반대로 바꿔준다. true -> false


            //int a = 10, b = 3;

            //Console.WriteLine(a + b);
            //Console.WriteLine(a - b);
            //Console.WriteLine(a * b);
            //Console.WriteLine(a / b);
            //Console.WriteLine(a % b);

            //string firstName = "Alice";
            //string lastName = "Smith";

            //Console.WriteLine(firstName + " " + lastName);

            int a = 5;
            int b = 4;
            int sum = 0;

            //a = a + b;
            //Console.WriteLine("a + b : " + a);
            //a = 5;
            //a = a - b;
            //Console.WriteLine("a - b : " + a);
            //a = 5;
            //a = a * b;
            //Console.WriteLine("a * b : " + a);
            //a = 5;
            //a = a / b;
            //Console.WriteLine("a / b : " + a);
            //a = 5;
            //a = a % b;
            //Console.WriteLine("a % b : " + a);

            //할당 연산자
            //a += b;

            a += b;
            Console.WriteLine("a + b : " + a);
            a = 5;
            a -= b;
            Console.WriteLine("a + b : " + a);
            a = 5;
            a *= b;
            Console.WriteLine("a * b : " + a);
            a = 5;
            a /= b;
            Console.WriteLine("a / b : " + a);
            a = 5;
            a %= b;
            Console.WriteLine("a % b : " + a);






        }
    }
}
