using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //default 키워드를 사용한 기본값 설정
            int defaultInt = default; // int의 기본값은 0
            string defaultString = default; // string의 기본값은 null
            bool defaultBool = default; // bool의 기본값은 false

            Console.WriteLine($"정수 기본값: {defaultInt}");
            Console.WriteLine($"문자열 기본값: {defaultString}");
            Console.WriteLine($"논리값 기본값: {defaultBool}");
        }
    }
}
