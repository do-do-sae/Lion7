using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////실수 데이터 형식: 소수점을 포함한 숫자를 표현
            //float singLePrecision = 3.14f; //단정밀도 실수 (4바이트)
            //double doublePrecision = 3.1415926535;  //배정밀도 실수 (8바이트)
            //decimal highPrecision = 3.1415926535897932384626433832m;  //고정밀도 (16바이트)

            //Console.WriteLine(singLePrecision);
            //Console.WriteLine(doublePrecision);
            //Console.WriteLine(highPrecision);

            //접미사 사용: 숫자의 데이터 형식을 명시
            //int integerValue = 100; //기본 정수형(int)
            //long longValue = 100L; //정수형(long)
            //float floatValue = 3.14f; //실수형(float)
            //double doubleValue = 3.14; //기본 실수형(double)
            //decimal decimalValue = 3.14m; //고정밀도 실수형(decimal)

            //Console.WriteLine(integerValue);
            //Console.WriteLine(longValue);
            //Console.WriteLine(floatValue);
            //Console.WriteLine(doubleValue);
            //Console.WriteLine(decimalValue);

            //char 형식: 단일 문자를 표현
            //char letter = 'A'; //answk 'A' 저장
            //char symbol = '#'; //특수 기호 저장
            //char number = '9'; //숫자 형태의 문자 저장(문자 '9')

            //Console.WriteLine(letter);
            //Console.WriteLine(symbol);
            //Console.WriteLine(number);

            //출력
            //이동속도 5.5f
            //공격속도 1.25

            float MOVESPEED = 5.5f;
            double ATTACKSPEED = 1.25;
            decimal ITEMPRICE = 12.99m;

            Console.WriteLine("==== 캐릭터 능력치 ===");
            Console.WriteLine($"이동속도: {MOVESPEED}");
            Console.WriteLine($"공격속도: {ATTACKSPEED}");
            Console.WriteLine($"아이템가격: {ITEMPRICE}");

        }
    }
}
