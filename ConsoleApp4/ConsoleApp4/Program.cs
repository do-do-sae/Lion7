using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //같은 데이터 타입의 변수를 쉼표로 구분해 한번에 선언
            //int x = 10, y = 20, z = 30; //정수형 x, y, z 변수 선언하고 초기화

            //Console.WriteLine(x); //x 변수 값 출력
            //Console.WriteLine(y); //y 변수 값 출력
            //Console.WriteLine(z); //z 변수 값 출력


            //int age = 20;
            //Console.WriteLine("나이: {0}", age);
            //string name = "철수";
            //Console.WriteLine("이름: {0}, 나이: {1}", name, age);

            //Console.WriteLine("나이: " + age);

            //Console.WriteLine($"나이: {age}"); //보간 문자열 (C# 6.0 이상))
            
            //Console.WriteLine($"나이: {age}, 이름: {name}"); //보간 문자열 (C# 6.0 이상)))

            // 3D 좌표 예시
            int posX = 0, posY = 50, posZ = 100;
            
            Console.WriteLine("3D 좌표: X={0}, Y={1}, Z={2}", posX, posY, posZ);

            Console.WriteLine("3D 좌표: X=" + posX + ", Y=" + posY + ", Z=" + posZ);

            Console.WriteLine($"3D 좌표: X={posX}, Y={posY}, Z={posZ}");


            // RGB 색상 값 예시
            int red = 255, green = 128, blue = 0;

            Console.WriteLine("RGB 색상 값: R={0}, G={1}, B={2}", red, green, blue);

            Console.WriteLine("RGB 색상 값: R=" + red + ", G=" + green + ", B=" + blue);

            Console.WriteLine($"RGB 색상 값: R={red}, G={green}, B={blue}");
        }
    }
}
