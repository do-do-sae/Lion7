using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int score = 85;
            //if (score >= 90)
            //{
            //    Console.WriteLine("A 학점");
            //}
            //else
            //{
            //    Console.WriteLine("90점 미만");
            //}
            //    int number = 10;
            //    if (number > 15)
            //    {

            //        Console.WriteLine("15보다 큽니다.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("15보다 작거나 같습니다.");
            //    }

            int score = 75;
            if (score >= 90)
            {
                Console.WriteLine("A 학점");
            }
            else if (score >= 80)
            {
                Console.WriteLine("B 학점");
            }
            else if (score >= 70)
            {
                Console.WriteLine("C 학점");
            }
            else
            {
                Console.WriteLine("F 학점");
            }





        }
    }
}
