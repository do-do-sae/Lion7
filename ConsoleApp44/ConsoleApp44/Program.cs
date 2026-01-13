using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp44
{
    internal class Program
    {
        static void HelloWorld()
        {
            Console.WriteLine("헬로월드");
            HelloWorld();
        }
        static void Main(string[] args)
        {
            //재귀함수 자기자신을 호출
            HelloWorld();
        }
    }
}
