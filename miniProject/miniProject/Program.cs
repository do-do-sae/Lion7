using System;
using System.Text;

namespace ConsoleMiniProject
{
    class Unit
    {
        public string Name;
        public int HP;
        public int MaxHP;
        public int Grade;

        public Unit(string name, int hp, int grade = 0)
        {
            Name = name;
            HP = hp;
            MaxHP = hp;
            Grade = grade;
        }

        public bool IsDead => HP <= 0;

        public string GetHealthBar()
        {
            int barLength = 20;
            float healthPercentage = Math.Max(0, (float)HP / MaxHP);
            int filledLength = (int)(barLength * healthPercentage);
            return $"[{(new string('■', filledLength))}{(new string('░', barLength - filledLength))}] {HP}/{MaxHP}";
        }
    }

    class Program
    {
        static int mapSize = 40;
        static int playerX = 0, playerY = 0;
        static int exitX = 39, exitY = 39;
        static char[,] map = new char[40, 40];
        static bool[,] traps = new bool[40, 40];
        static bool[,] items = new bool[40, 40];
        static string[,] itemType = new string[40, 40];

        static Unit player;
        static Random rand = new Random();

        static int exLevel = 0;   // 크게베기 (검정/하얀색으로 대체)
        static int moonLevel = 0; // 얼음화살 (파랑)
        static int mystLevel = 0; // 라이트닝 (노랑)
        static int dungeonLevel = 1;

        static void Main(string[] args)
        {
            Console.Title = "던전 탈출: 속성 마스터 에디션";
            Console.CursorVisible = true;
            try { Console.SetWindowSize(110, 55); } catch { }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================================");
            Console.WriteLine("              모험의 시작: 용사의 이름              ");
            Console.WriteLine("====================================================");
            Console.ResetColor();
            Console.Write("\n 당신의 이름을 입력하세요: ");
            string inputName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputName)) inputName = "무명용사";

            player = new Unit(inputName, 200);
            Console.CursorVisible = false;

            while (true)
            {
                SetupGame();
                bool isCleared = PlayLevel();
                if (isCleared)
                {
                    ShowGameClear();
                    Console.WriteLine($"\n [ 현재 {dungeonLevel}층 돌파 성공! ]");
                    Console.WriteLine(" 1. 다음 층으로 | 2. 종료");
                    string choice = Console.ReadLine();
                    if (choice == "1") { dungeonLevel++; player.HP = Math.Max(player.HP, (int)(player.MaxHP * 0.2f)); continue; }
                    else { ShowFinalResult(); break; }
                }
                else { ShowGameOver(); break; }
            }
        }

        static bool PlayLevel()
        {
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                DrawMapFast();
                PrintStatus();
                if (player.IsDead) return false;
                if (playerX == exitX && playerY == exitY) return true;
                MovePlayer(Console.ReadKey(true));
                CheckEvent();
            }
        }

        static void SetupGame()
        {
            playerX = 0; playerY = 0;
            Array.Clear(map, 0, map.Length);
            Array.Clear(traps, 0, traps.Length);
            Array.Clear(items, 0, items.Length);
            Array.Clear(itemType, 0, itemType.Length);
            for (int i = 0; i < 250; i++)
            {
                int wx = rand.Next(1, mapSize - 1), wy = rand.Next(1, mapSize - 1);
                if (Math.Abs(wx - playerX) + Math.Abs(wy - playerY) < 3 || Math.Abs(wx - exitX) + Math.Abs(wy - exitY) < 3) continue;
                map[wy, wx] = '#';
            }
            int mCount = 0;
            while (mCount < 50)
            {
                int rx = rand.Next(0, mapSize), ry = rand.Next(0, mapSize);
                if (map[ry, rx] == '#' || traps[ry, rx]) continue;
                traps[ry, rx] = true; mCount++;
            }
            string[] treasures = { "엑스칼리버", "월광", "미스틸테인" };
            int iCount = 0;
            while (iCount < 20)
            {
                int rx = rand.Next(0, mapSize), ry = rand.Next(0, mapSize);
                if (map[ry, rx] == '#' || traps[ry, rx] || items[ry, rx]) continue;
                items[ry, rx] = true;
                itemType[ry, rx] = (iCount < 9) ? treasures[iCount % 3] : "포션";
                iCount++;
            }
        }

        static void DrawMapFast()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (i == playerY && j == playerX) sb.Append("P ");
                    else if (i == exitY && j == exitX) sb.Append("E ");
                    else if (map[i, j] == '#') sb.Append("# ");
                    else if (items[i, j]) sb.Append("? ");
                    else if (traps[i, j]) sb.Append("M ");
                    else sb.Append(". ");
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        static void PrintStatus()
        {
            Console.WriteLine($"\n[LV.{dungeonLevel}] {player.Name} HP: {player.GetHealthBar()}");
            Console.Write("보유 유물: ");
            if (exLevel > 0) { Console.ForegroundColor = ConsoleColor.White; Console.Write($"[엑스칼리버 +{exLevel}] "); }
            if (moonLevel > 0) { Console.ForegroundColor = ConsoleColor.Blue; Console.Write($"[월광 +{moonLevel}] "); }
            if (mystLevel > 0) { Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($"[미스틸테인 +{mystLevel}] "); }
            Console.ResetColor(); Console.WriteLine("\nWASD: 이동 | M: 전투 시작");
        }

        static void MovePlayer(ConsoleKeyInfo key)
        {
            int nx = playerX, ny = playerY;
            if (key.Key == ConsoleKey.W) ny--;
            else if (key.Key == ConsoleKey.S) ny++;
            else if (key.Key == ConsoleKey.A) nx--; else if (key.Key == ConsoleKey.D) nx++;
            if (nx >= 0 && nx < mapSize && ny >= 0 && ny < mapSize && map[ny, nx] != '#') { playerX = nx; playerY = ny; }
        }

        static void CheckEvent()
        {
            if (items[playerY, playerX])
            {
                string t = itemType[playerY, playerX];
                if (t == "포션") { int h = rand.Next(40, 70); player.HP = Math.Min(player.MaxHP, player.HP + h); }
                else if (t == "엑스칼리버") exLevel++; else if (t == "월광") moonLevel++; else if (t == "미스틸테인") mystLevel++;
                items[playerY, playerX] = false; Console.Clear();
            }
            if (traps[playerY, playerX]) { if (StartBattle()) traps[playerY, playerX] = false; Console.Clear(); }
        }

        static void DrawEntity(string name)
        {
            // 몬스터별 색상 적용
            switch (name)
            {
                case "고블린": Console.ForegroundColor = ConsoleColor.Green; break;
                case "강철 골렘": Console.ForegroundColor = ConsoleColor.Gray; break;
                case "심연의 드래곤": Console.ForegroundColor = ConsoleColor.Red; break;
            }

            switch (name)
            {
                case "고블린":
                    Console.WriteLine(@"
              _   _          [ 상성 가이드 ]
             ( \_/ )         얼음화살 -> 고블린 (강함)
            / @   @ \        라이트닝 -> 고블린 (약함)
           ( >  0  < )       
            \_______/        ""키킥.. 얼음은 싫어!"" ");
                    break;
                case "강철 골렘":
                    Console.WriteLine(@"
             _________       [ 상성 가이드 ]
            /         \      라이트닝 -> 골렘 (강함)
           |  [O] [O]  |     크게베기 -> 골렘 (약함)
           |   _____   |     
           |  |_____|  |     ""찌릿찌릿.. 과부하.."" ");
                    break;
                case "심연의 드래곤":
                    Console.WriteLine(@"
                  __    __   [ 상성 가이드 ]
                 /  \  /  \  크게베기 -> 드래곤 (강함)
           _____/ __ \/ __ \ 얼음화살 -> 드래곤 (약함)
          /      \  /  \  /  
         |  (X)   \/    \/   ""칼날이.. 따갑구나!"" ");
                    break;
            }
            Console.ResetColor();
        }

        static bool StartBattle()
        {
            int hpBonus = (dungeonLevel - 1) * 50;
            Unit monster = (rand.Next(0, 100) < 60) ? new Unit("고블린", 100 + hpBonus, 0) :
                           (rand.Next(0, 100) < 90) ? new Unit("강철 골렘", 250 + hpBonus, 1) :
                           new Unit("심연의 드래곤", 600 + hpBonus, 2);

            string log = $"{monster.Name}과 전투 시작!";

            while (!player.IsDead && !monster.IsDead)
            {
                Console.Clear();
                Console.WriteLine($"\n======================= {dungeonLevel}층 전투 =======================");
                DrawEntity(monster.Name);
                Console.WriteLine("=========================================================");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($" [플레이어] {player.Name} : {player.GetHealthBar()}");
                Console.WriteLine("=========================================================");

                // 스킬 메뉴 출력 (색상 적용)
                PrintSkillMenu(1, "크게베기/엑스칼리버", exLevel, 30 + (exLevel * 50), ConsoleColor.White);
                PrintSkillMenu(2, "얼음화살/월광", moonLevel, 25 + (moonLevel * 40), ConsoleColor.Blue);
                PrintSkillMenu(3, "라이트닝/미스틸테인", mystLevel, 50 + (mystLevel * 70), ConsoleColor.Yellow);

                Console.Write("\n 행동 선택: ");
                string c = Console.ReadLine();
                int baseDamage = 0; string attr = "";
                if (c == "1") { baseDamage = 30 + (exLevel * 50); attr = "PHYSICAL"; }
                else if (c == "2") { baseDamage = 25 + (moonLevel * 40); attr = "ICE"; }
                else if (c == "3") { baseDamage = 50 + (mystLevel * 70); attr = "LIGHTNING"; }
                else continue;

                // 상성 계산 로직
                float modifier = 1.0f;
                if (monster.Name == "고블린")
                {
                    if (attr == "ICE") modifier = 2.0f;
                    else if (attr == "LIGHTNING") modifier = 0.5f;
                }
                else if (monster.Name == "강철 골렘")
                {
                    if (attr == "LIGHTNING") modifier = 2.0f;
                    else if (attr == "PHYSICAL") modifier = 0.5f;
                }
                else if (monster.Name == "심연의 드래곤")
                {
                    if (attr == "PHYSICAL") modifier = 2.0f;
                    else if (attr == "ICE") modifier = 0.5f;
                }

                int finalDamage = (int)(baseDamage * modifier);
                monster.HP -= finalDamage;
                log = $"{finalDamage} 데미지! " + (modifier > 1.0f ? "(효과가 굉장했다!)" : modifier < 1.0f ? "(효과가 별로다..)" : "");

                if (!monster.IsDead)
                {
                    int md = rand.Next(15, 25) + (monster.Grade * 20) + (dungeonLevel * 5);
                    player.HP -= md;
                    log += $" / {monster.Name}의 {md} 반격!";
                }
            }
            if (player.IsDead) return false;
            Console.WriteLine("\n전투 승리!"); Console.ReadKey(); return true;
        }

        static void PrintSkillMenu(int num, string name, int level, int damage, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($" {num}. {name} ");
            Console.ResetColor();
            Console.WriteLine($"(기본: {damage}) " + (level > 0 ? $"[+{level} 강화]" : ""));
        }

        static void ShowGameOver()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
    ====================================================
 _____   ___  ___  ___ _____   _____  _   _  _____ ______ 
|  __ \ / _ \ |  \/  ||  ___| |  _  || | | ||  ___|| ___ \
| |  \// /_\ \| .  . || |__   | | | || | | || |__  | |_/ /
| | __ |  _  || |\/| ||  __|  | | | || | | ||  __| |    / 
| |_\ \| | | || |  | || |___  \ \_/ /\ \_/ /| |___ | |\ \      
 \____/\_| |_/\_|  |_/\____/   \___/  \___/ \____/ \_| \_|    
    ====================================================
            던전의 어둠이 당신을 삼켰습니다...");
            Console.ResetColor(); Console.ReadKey();
        }
        static void ShowGameClear()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
====================================================
         _____  _       _____   ___  ______ 
        /  __ \| |     |  ___| / _ \ | ___ \
        | /  \/| |     | |__  / /_\ \| |_/ /
        | |    | |     |  __| |  _  ||    / 
        | \__/\| |____| |___ | | | || |\ \ 
         \____/\_____/\____/ \_| |_/\_| \_|
====================================================
       당신은 던전의 전설이 되어 돌아왔습니다!");
            Console.ResetColor();
        }
        static void ShowFinalResult()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("====================================================");
            Console.WriteLine("               🎉 전설의 용사 성적표 🎉               ");
            Console.WriteLine("====================================================");
            Console.ResetColor();

            Console.WriteLine($"\n ▶ 최종 돌파 층수: {dungeonLevel}층");
            Console.WriteLine($" ▶ 용사의 이름    : {player.Name}");

            Console.WriteLine("\n [ 최종 유물 강화 상태 ]");
            Console.WriteLine($" - 엑스칼리버: +{exLevel}");
            Console.WriteLine($" - 월광      : +{moonLevel}");
            Console.WriteLine($" - 미스틸테인: +{mystLevel}");

            Console.WriteLine("\n====================================================");
            Console.WriteLine("     고생하셨습니다! 아무 키나 누르면 종료됩니다.     ");
            Console.WriteLine("====================================================");
            Console.ReadKey();
        }
    }
}