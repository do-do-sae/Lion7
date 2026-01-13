using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp38
{
    internal class Program
    {
        //반환값이 있는 함수 3단계


        //정수 반환
        static int GetNumber() //정수반환
        {
            return 42;
        }
        //문자열 반환
        static string ConnectMessage(string name)
        {
            return name + "님 접속하셨습니다.";
        }


        static void Main(string[] args)
        {
            int num = GetNumber();
            Console.WriteLine("숫자 반환 : " + num);

            Console.Write("이름을 입력하세요 : ");
            string cm = ConnectMessage(Console.ReadLine());

            Console.WriteLine(cm);
        }
    }
}
