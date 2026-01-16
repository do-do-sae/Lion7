using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp59
{
    //추상 클래스 상속을 받고있는 친구는 추상메서드를 상속받아서 꼭 구현해라
    public abstract class Character //abstract 키워드{
    {
        public int hp;
        public abstract void Job();
    }
    public class Mage : Character
    {
        public override void Job()
        {
            Console.WriteLine("마법사 선택");
        }
    }
    public class Archer : Character
    {
        public override void Job()
        {
            Console.WriteLine("아처 선택");
        }
    }
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Character[] ch = new Character[2]; //배열준비
            //수집형 알피지 캐릭터 두개 뽑았다.
            ch[0] = new Mage();
            ch[1] = new Archer();
            //for (int i = 0; i < ch.Length; i++)
            //{
            //    ch[i].Job();
            //}
            foreach (Character c in ch)
            {
                c.Job();
            }
        }
    }
}
