using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////숫자 데이터 형식: 정수와 실수를 다룰 때 사용하는 다양한 타입
            //int integerNum = 10; //정수 데이터
            //float floatNum = 3.14f; //단정밀도 실수
            //double doubleNum = 3.141592; //배정밀도 실수

            //Console.WriteLine(integerNum); //출력: 10
            //Console.WriteLine(floatNum); //출력: 3.14
            //Console.WriteLine(doubleNum); //출력: 3.141592

            byte level = 50;                    //레벨 (0~255)
            short attack = 1500;                //공격력
            int gold = 1234567;                 //소지금
            long experience = 99999999L;        //경험치(L 접미사 필수)

            Console.WriteLine("=== 캐릭터 정보 ===");
            Console.WriteLine($"레벨: {level}");
            Console.WriteLine($"공격력: {attack}");
            Console.WriteLine($"소지금: {gold:N0}골드");     // N0: 천 단위 구분기호 표시
            Console.WriteLine($"경험치: {experience:N0}점");

            //타입별 최대값 확인
            Console.WriteLine("\n=== 타입별 최대값 ==="); 
            Console.WriteLine($"byte 최대값: {byte.MaxValue}");
            Console.WriteLine($"short 최대값: {short.MaxValue}");
            Console.WriteLine($"int 최대값: {int.MaxValue}");
            Console.WriteLine($"long 최대값: {long.MaxValue}");


        }
    }
}
