using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //다차원 배열
            //### 배열 크기 확인
            //int[,] array = new int[3, 4];

            ////전체 요소 개수
            //int totalElements = array.Length; // 12 (3 x 4)_
            ////특정 차원의 길이
            //int rows = array.GetLength(0); // 3 (행 개수)
            //int cols = array.GetLength(1); // 4 (열 개수)
            ////Rank: 배열의 차원 수
            //int dimensions = array.Rank; //2

            //string[,] playerSeat =
            //{
            //    {"[A1]","[A2]","[A3]"},
            //    {"[B1]","[B2]","[B3]"},
            //    {"[C1]","[C2]","[C3]"},
            //};
            //for (int i = 0; i < playerSeat.GetLength(0); i++)
            //{
            //    for (int j = 0; j < playerSeat.GetLength(1); j++)
            //    {
            //        Console.Write(playerSeat[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine("첫 번째 좌석: " + playerSeat[0, 0]);
            //Console.WriteLine("중앙 좌석: " + playerSeat[1, 2]);
            //Console.WriteLine("마지막 좌석: " + playerSeat[2, 2]);
            //Console.OutputEncoding = Encoding.UTF8;

            //int[,] map = 
            //{
            //    { 0, 0, 1, 0, 0 },
            //    { 0, 2, 1, 0, 3 },
            //    { 0, 0, 1, 0, 0 },
            //    { 1, 1, 1, 0, 0 },
            //    { 0, 0, 0, 0, 9 },
            //};

            //Console.WriteLine("==던전맵==");
            //Console.WriteLine("0: 통로 1: 벽 2: 몬스터 3: 보물 9: 출구 \n");

            ////맵 출력
            //for(int y = 0; y < map.GetLength(0); y++)
            //{
            //    for(int x = 0; x < map.GetLength(1); x++)
            //    {
            //        switch(map[x, y])
            //        {
            //            case 0:
            //                Console.Write("⬜ ");
            //                break;
            //            case 1:
            //                Console.Write("⬛ ");
            //                break;
            //            case 2:
            //                Console.Write("👹 ");
            //                break;
            //            case 3:
            //                Console.Write("💎 ");
            //                break;
            //            case 9:
            //                Console.Write("🚪 ");
            //                break;
            //        }
            //    }
            //    Console.WriteLine();
            //학생 3명, 과목 4개(국어, 영어, 수학, 과학)
            //int[,] scores = new int[3, 4]
            //{
            //{ 85, 90, 88, 92 },  // 학생 1
            //{ 78, 85, 90, 87 },  // 학생 2
            //{ 92, 88, 95, 90 }   // 학생 3
            //};

            //string[] students = { "김철수", "이영희", "박민수" };
            //string[] subjects = { "국어", "영어", "수학", "과학" };

            //Console.WriteLine("=== 성적표 ===\n");

            //// 헤더 출력
            //Console.Write("이름\t");
            //foreach (string subject in subjects)
            //{
            //    Console.Write($"{subject}\t");
            //}
            //Console.WriteLine("평균");
            //Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

            //// 학생별 성적 출력
            //for (int i = 0; i < scores.GetLength(0); i++)
            //{
            //    Console.Write($"{students[i]}\t");

            //    int sum = 0;
            //    for (int j = 0; j < scores.GetLength(1); j++)
            //    {
            //        Console.Write($"{scores[i, j]}\t");
            //        sum += scores[i, j];
            //    }

            //    double average = (double)sum / scores.GetLength(1);
            //    Console.WriteLine($"{average:F1}");
            //}

            //// 과목별 평균
            //Console.WriteLine("\n=== 과목별 평균 ===");
            //for (int subject = 0; subject < scores.GetLength(1); subject++)
            //{
            //    int sum = 0;
            //    for (int student = 0; student < scores.GetLength(0); student++)
            //    {
            //        sum += scores[student, subject];
            //    }
            //    double avg = (double)sum / scores.GetLength(0);
            //    Console.WriteLine($"{subjects[subject]}: {avg:F1}점");
            //}


            //가변 배열
            string[][] raid = new string[3][];

            raid[0] = new string[] { "전사", "힐러", "마법사", "궁수" };
            raid[1] = new string[] { "도적", "전사", "힐러" };
            raid[2] = new string[] { "마법사", "궁수", "힐러", "전사", "탱커" };

            Console.WriteLine("=== 레이드 파티 구성 ===");
            for (int i = 0; i < raid.Length; i++)
            {
                Console.WriteLine($"파티 {i + 1} ({raid[i].Length}명): ");
                for (int j = 0; j < raid[i].Length; j++)
                {
                    Console.WriteLine($" - {raid[i][j]}");
                }
            }

            ////동적배열
            //List<int> numbers = new List<int>(); //빈 리스트
            //List<string> names = new List<string>(); //문자열 리스트
            //List<float> prices = new List<float>(); //실수 리스트
            ////초기값과 함께 선언
            //List<int> socres = new List<int> { 85, 90, 78, 95 };
            /////C# 3.0 이후 간단한 초기화
            /////var players = new List<string> { "철수", "영희", "민수" };
            //List<string> items = new List<string>();

            //// Add: 끝에 추가
            //items.Add("회복 포션");
            //items.Add("마나 포션");
            //Console.WriteLine(items);

            //List 생성
            //List<string> inventory = new List<string>();

            //Console.WriteLine("=== 도적 인벤토리 시스템 ===");
            ////아이템 추가 (Add)
            //inventory.Add("회복 포션");
            //inventory.Add("마나 포션");
            //inventory.Add("강철 검");
            //inventory.Add("독버섯");
            //Console.WriteLine("아이템 3개 추가");

            ////현재 인벤토리
            //Console.WriteLine($"인벤토리 ({inventory.Count}개): ");

            //for (int i = 0; i < inventory.Count; i++)
            //{
            //    Console.WriteLine($"[{i + 1}] {inventory[i]}");
            //}
            //Console.WriteLine();
            //Console.WriteLine("인벤토리 1번 변경");
            //inventory[0] = "초록 포션";
            //for (int i = 0; i < inventory.Count; i++)
            //{
            //    Console.WriteLine($"[{i + 1}] {inventory[i]}");
            //}
            //Console.WriteLine();
            ////특정 위치에 추가(Insert)
            //inventory.Insert(1, "전설 검");

            //for (int i = 0;i < inventory.Count; i++)
            //{
            //    Console.WriteLine($"[{i + 1}] {inventory[i]}");
            //}
            //Console.WriteLine();
            ////아이템 제거 (Remove)
            //inventory.Remove("초록 포션");

            //for (int i = 0; i < inventory.Count; i++)
            //{
            //    Console.WriteLine($"[{i + 1}] {inventory[i]}");
            //}
            //Console.WriteLine();
            ////인덱스로 제거 (RemoveAt)
            //inventory.RemoveAt(0);

            //for (int i = 0; i < inventory.Count; i++)
            //{
            //    Console.WriteLine($"[{i + 1}] {inventory[i]}");
            //}
            //Console.WriteLine();

            //Dictionary<string, int> stats = new Dictionary<string, int>();

            ////데이터 추가
            //stats.Add("HP", 150);
            //stats.Add("MP", 80);
            //stats.Add("공격력", 75);
            //stats.Add("방어력", 50);
            //stats.Add("민첩", 60);


            //Console.WriteLine("=== 캐릭터 스탯 ===");

            //foreach(KeyValuePair<string, int> stat in stats)
            //{
            //    Console.WriteLine($"{stat.Key}: {stat.Value}");
            //}
            ////키 존재 확인
            //string searchStat = "방어력";

            //if(stats.ContainsKey(searchStat))
            //{
            //    Console.WriteLine(stats[searchStat]);
            //}
            //else
            //{
            //    Console.WriteLine("해당스탯이 없습니다.");
            //}
            //Dictionary<string, int> Item =new Dictionary<string, int>();
            //Item.Add("회복 포션", 50);
            //Item.Add("마나 포션", 40);
            //Item.Add("강철 검", 500);
            //Item.Add("가죽 갑옷", 300);
            //Item.Add("마법 반지", 1000);

            //Console.WriteLine("=== 상점 아이템 ===");
            //foreach(KeyValuePair<string, int> items in Item)
            //{
            //    Console.WriteLine($"{items.Key}: {items.Value}골드");
            //}
            //Console.WriteLine();
            //int playerGold = 900;
            //Console.Write($"구매할 아이템을 입력하세요(사용 가능 골드 : {playerGold}): ");
            //string radItem = Console.ReadLine();

            //if (Item.ContainsKey(radItem))
            //{
            //    int itemPrice = Item[radItem];
            //    if(itemPrice <= playerGold )
            //    {
            //        playerGold -= itemPrice;
            //        Console.WriteLine($"'{radItem}' 구매 성공!");
            //        Console.WriteLine($"남은 골드 : {playerGold}골드");
            //    }
            //    else
            //    {
            //        Console.WriteLine("골드 부족..");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("정확히 입력해주세요");
            //}



        }
    }
}
