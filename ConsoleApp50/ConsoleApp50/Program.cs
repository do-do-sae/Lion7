using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp50
{

    class Character
    {
        //private int Att; //은닉성

        ////Get / Set 함수
        //public void SetAtt(int _Att) //일반함수
        //{
        //    Att = _Att;
        //}
        //public int GetAtt() //일반함수
        //{
        //    return Att;
        //}

        private int att;
        public int Att { get; set; } //자동프로퍼티
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Character c = new Character();

            c.Att = 10;
            Console.WriteLine($"공격력 : {c.Att}");
        }
    }
}
