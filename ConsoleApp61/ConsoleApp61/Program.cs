using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    //인터페이스 
    interface IAttackable
    {
        void Attack(string target);
        int GetAttackPower();
    }

    //인터페이스 Defendable 구현 방어기능
    interface IDefendable
    {
        void Defend();
        int GetDefensePower();
    }


    class Knight : IAttackable, IDefendable //알트 + 엔터
    {

        public string name;
        public int attackPower;
        public int defensePower;

        public Knight()
        {
            name = "검사";
            attackPower = 10;
            defensePower = 5;
        }

        public void Attack(string target)
        {
            Console.WriteLine($"검으로 {target}를 공격 했습니다.");

        }

        public void Defend()
        {
            Console.WriteLine("기사가 방어모드중입니다.");
        }

        public int GetAttackPower()
        {
            return attackPower;
        }

        public int GetDefensePower()
        {
            return defensePower;
        }
    }

    //마법사클래스를 만들고 어택 인터페이스를 구현하시오
    class Mage : IAttackable  //알트 + 엔터
    {

        public string name;
        public int attackPower;

        public Mage()
        {
            name = "검사";
            attackPower = 10;
        }

        public void Attack(string target)
        {
            Console.WriteLine($"마법으로 {target}를 공격 했습니다.");

        }

        public int GetAttackPower()
        {
            return attackPower;
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {

            //Knight knight = new Knight();
            //knight.Attack("오크");
            //knight.Defend();

            //Mage mage = new Mage();
            //mage.Attack("고블린");


            //인터페이스 타입으로 배열 생성
            IAttackable[] attacker = new IAttackable[2]; //배열만 준비
            attacker[0] = new Knight();
            attacker[1] = new Mage();

            IDefendable defender = new Knight();
            defender.Defend();










        }
    }
}