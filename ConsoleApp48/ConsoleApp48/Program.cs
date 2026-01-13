using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp48
{
    //캐릭터 클래스 정의
    class Character
    {
        // 필드 (Field): 클래스의 데이터
        private string name;
        private int level;
        private int hp;
        private int maxHP;
        private int mp;
        private int maxMP;

        public void SetInfo(string _name, int _level, int _hp, int _maxHP, int _mp, int _maxMP)
        {
            name = _name;
            level = _level;
            hp = _hp;
            maxHP = _maxHP;
            mp = _mp;
            maxMP = _maxMP;
        }

        // 메서드 (Method): 클래스의 기능
        public void ShowInfo()
        {
            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine($"이름: {name}");
            Console.WriteLine($"레벨: {level}");
            Console.WriteLine($"HP: {hp}/{maxHP}");
            Console.WriteLine($"MP: {mp}/{maxMP}");
            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━");
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp < 0) hp = 0;
            Console.WriteLine($"⚔️ {name}이(가) {damage} 데미지를 받았습니다!");
            Console.WriteLine($"   남은 HP: {hp}/{maxHP}");
        }

        public void Heal(int amount)
        {
            hp += amount;
            if (hp > maxHP) hp = maxHP;
            Console.WriteLine($"💚 {name}의 HP가 {amount} 회복되었습니다!");
            Console.WriteLine($"   현재 HP: {hp}/{maxHP}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //절차 지향 프로그래밍 vs 객체지향방식

            //객체 생성
            Character player1 = new Character();
            player1.SetInfo("홍길동", 10, 150, 150, 80, 80);
            //메서드 호출 출력
            player1.ShowInfo();
            //데미지 50
            player1.TakeDamage(50);
            //힐 30
            player1.Heal(30);
            //새로운 객체 생성해서 임의값 입력 후 출력
            Character player2 = new Character();
            player2.SetInfo("전사", 50, 600,600, 120, 120);
            player2.ShowInfo();
            player2.TakeDamage(50);
            player2.Heal(30);
        }
    }
}
