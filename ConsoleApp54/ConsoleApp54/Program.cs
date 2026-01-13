using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp54
{
    class Skill
    {
        //필드 / 변수
        private string name;
        private int att;

        public Skill()
        {

        }

        public Skill(string name, int att)
        {
            this.name = name;
            this.att = att;
        }
        public void SkillStart()
        {
            Console.WriteLine("스킬 이름 : " + this.name);
            Console.WriteLine("스킬 데미지 : " + this.att);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Skill s = new Skill("블리자드", 100000);
            s.SkillStart();
        }
    }
}
