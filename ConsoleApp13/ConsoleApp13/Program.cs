using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.Int32 number = 123;
            //System.String text = "Hello";
            //System.Boolean flag = true;

            //Console.WriteLine($"number: {number}, text: {text}, flag: {flag}");

            int number = 123;
            string numberAsString = number.ToString(); //정수를 문자열로 변환

            bool flag = true;
            string flagAsString = flag.ToString(); //논리값을 문자열로 변환

            string text = "456";
            int stringAsNumber = int.Parse(text); //문자열을 정수로 변환
            
            Console.WriteLine(numberAsString); //"123"
            Console.WriteLine(flagAsString); //"True"
            Console.WriteLine(stringAsNumber); //456
        }
    }
}
