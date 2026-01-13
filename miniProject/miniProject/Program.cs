using System;

namespace ConsoleMiniProject
{
    class Unit
    {
        public string Name;
        public int HP;
        public int MaxHP;
        public int Grade; // 0: 일반, 1: 정예, 2: 보스

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
            float healthPercentage = (float)HP / MaxHP;
            if (healthPercentage < 0) healthPercentage = 0;

            int filledLength = (int)(barLength * healthPercentage);
            string bar = new string('■', filledLength);
            string empty = new string('░', barLength - filledLength);

            return $"[{bar}{empty}] {HP}/{MaxHP}";
        }
    }

    class Program
    {
        static int mapSize = 20;
        static int playerX = 0, playerY = 0;
        static int exitX = 19, exitY = 19;

        static char[,] map = new char[20, 20];
        static bool[,] traps = new bool[20, 20];
        static bool[,] items = new bool[20, 20];
        static string[,] itemType = new string[20, 20];

        static Unit player;
        static Random rand = new Random();

        // 유물 상태
        static bool hasExcalibur = false;   // 크게베기 강화
        static bool hasMoonlight = false;   // 얼음화살 강화
        static bool hasMysteltein = false;  // 라이트닝 강화

        static void Main(string[] args)
        {
            Console.Title = "던전 탈출: 하드코어 밸런스";
            SetupGame();

            while (true)
            {
                Console.Clear();
                DrawMap();

                Console.WriteLine($"\n{player.Name} 상태: {player.GetHealthBar()}");
                Console.WriteLine("보유 유물: " +
                    (hasExcalibur ? " [엑스칼리버]" : "") +
                    (hasMoonlight ? " [월광]" : "") +
                    (hasMysteltein ? " [미스틸테인]" : " 없음"));
                Console.WriteLine("WASD: 이동 | #: 벽, ?: 보물/포션 (함정 몬스터는 숨어있습니다)");

                MovePlayer(Console.ReadKey(true));
                CheckEvent();

                if (player.IsDead) { ShowGameOver(); break; }
                if (playerX == exitX && playerY == exitY) { ShowGameClear(); break; }
            }
        }

        static void SetupGame()
        {
            player = new Unit("용사", 120); // 초기 HP 하향 (긴장감 조성)

            // 1. 벽 생성 (70개로 증량 - 더 복잡한 미로)
            for (int i = 0; i < 70; i++)
            {
                int wx = rand.Next(1, mapSize - 1);
                int wy = rand.Next(1, mapSize - 1);
                if (Math.Abs(wx - 0) + Math.Abs(wy - 0) < 3 || Math.Abs(wx - exitX) + Math.Abs(wy - exitY) < 3) continue;
                map[wy, wx] = '#';
            }

            // 2. 몬스터 배치 (20마리)
            int mCount = 0;
            while (mCount < 20)
            {
                int rx = rand.Next(0, mapSize), ry = rand.Next(0, mapSize);
                if (map[ry, rx] == '#' || (rx == 0 && ry == 0) || (rx == exitX && ry == exitY) || traps[ry, rx]) continue;
                traps[ry, rx] = true; mCount++;
            }

            // 3. 아이템 배치 (보물 3개, 포션 6개)
            string[] treasures = { "엑스칼리버", "월광", "미스틸테인" };
            int iCount = 0;
            while (iCount < 9)
            {
                int rx = rand.Next(0, mapSize), ry = rand.Next(0, mapSize);
                if (map[ry, rx] == '#' || traps[ry, rx] || items[ry, rx]) continue;
                items[ry, rx] = true;
                itemType[ry, rx] = (iCount < 3) ? treasures[iCount] : "포션";
                iCount++;
            }
        }

        static void DrawMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (i == playerY && j == playerX) { Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("P "); }
                    else if (i == exitY && j == exitX) { Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("E "); }
                    else if (map[i, j] == '#') { Console.ForegroundColor = ConsoleColor.White; Console.Write("# "); }
                    else if (items[i, j]) { Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("? "); }
                    else { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(". "); }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static void MovePlayer(ConsoleKeyInfo key)
        {
            int nx = playerX, ny = playerY;
            switch (key.Key)
            {
                case ConsoleKey.W: ny--; break;
                case ConsoleKey.S: ny++; break;
                case ConsoleKey.A: nx--; break;
                case ConsoleKey.D: nx++; break;
            }
            if (nx >= 0 && nx < mapSize && ny >= 0 && ny < mapSize && map[ny, nx] != '#')
            {
                playerX = nx; playerY = ny;
            }
        }

        static void CheckEvent()
        {
            if (items[playerY, playerX])
            {
                string t = itemType[playerY, playerX];
                if (t == "포션")
                {
                    int h = rand.Next(15, 30); player.HP = Math.Min(player.MaxHP, player.HP + h);
                    Console.WriteLine($"\n[+] 낡은 포션을 발견했습니다. HP +{h}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\n[★] {t}을(를) 획득했습니다! 무기의 기운이 달라집니다.");
                    if (t == "엑스칼리버") hasExcalibur = true;
                    if (t == "월광") hasMoonlight = true;
                    if (t == "미스틸테인") hasMysteltein = true;
                    Console.ResetColor();
                }
                items[playerY, playerX] = false; Console.ReadKey();
            }
            if (traps[playerY, playerX]) { if (StartBattle()) traps[playerY, playerX] = false; }
        }

        static bool StartBattle()
        {
            int r = rand.Next(0, 100);
            // 밸런스 조정: 몬스터 체력 대폭 상향
            Unit monster = (r < 50) ? new Unit("해골 병사", 70, 0) :
                           (r < 85) ? new Unit("강철 골렘", 180, 1) :
                           new Unit("심연의 드래곤", 450, 2);

            string log = $"{monster.Name}이(가) 당신의 앞을 막아섰습니다!";

            while (!player.IsDead && !monster.IsDead)
            {
                Console.Clear();
                Console.WriteLine("======================= 위 기 상 황 =======================");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($" PLAYER : {player.GetHealthBar()}");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($" ENEMY  : {monster.GetHealthBar()}");
                Console.ResetColor();
                Console.WriteLine("=========================================================");
                Console.WriteLine($" 상황: {log}");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine($" 1. 크게베기 [근접]   {(hasExcalibur ? "-> [엑스칼리버]" : "")}");
                Console.WriteLine($" 2. 얼음화살 [제어]   {(hasMoonlight ? "-> [월광]" : "")}");
                Console.WriteLine($" 3. 라이트닝 [폭발]   {(hasMysteltein ? "-> [미스틸테인]" : "")}");
                Console.Write(" 행동 선택: ");

                string c = Console.ReadLine();
                int pd = 0; int ps = 0; // 플레이어 데미지, 플레이어 자가 피해

                if (c == "1") pd = hasExcalibur ? 65 : 25;
                else if (c == "2") pd = hasMoonlight ? 50 : 20;
                else if (c == "3") { pd = hasMysteltein ? 100 : 45; ps = 10; } // 라이트닝은 자가피해 10 발생

                monster.HP -= pd;
                player.HP -= ps;
                log = (pd > 0) ? $"{player.Name}의 공격! ({pd} 피해" + (ps > 0 ? $", 자신도 {ps} 피해)" : ")") : "공격이 빗나갔습니다!";

                if (!monster.IsDead)
                {
                    // 몬스터 공격력 강화
                    int md = rand.Next(12, 22) + (monster.Grade * 20);
                    player.HP -= md; log += $" / {monster.Name}의 반격! ({md} 피해)";
                }
            }
            if (player.IsDead) return false;
            Console.WriteLine($"\n전투 승리! 숨을 고르며 전진합니다."); Console.ReadKey(); return true;
        }

        static void ShowGameOver()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
====================================================
  _____   ___  ___  ___ _____   _____  _   _  _____ ______ 
 |  __ \ / _ \ |  \/  ||  ___| |  _  || | | ||  ___|| ___ \
 | |  \// /_\ \| .  . || |__   | | | || | | || |__  | |_/ /
 | | __ |  _  || |\/| ||  __|  | | | || | | ||  __| |  __/ 
 | |_\ \| | | || |  | || |___  \ \_/ /\ \_/ /| |___ | |    
  \____/\_| |_/\_|  |_/\____/   \___/  \___/ \____/ \_|    
====================================================
           던전의 어둠이 당신을 삼켰습니다...");
            Console.ResetColor(); Console.ReadKey();
        }

        static void ShowGameClear()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
====================================================
  _____  _      _____   ___  ______ 
 /  __ \| |    |  ___| / _ \ | ___ \
 | /  \/| |    | |__  / /_\ \| |_/ /
 | |    | |    |  __| |  _  ||    / 
 | \__/\| |____| |___ | | | || |\ \ 
  \____/\_____/\____/ \_| |_/\_| \_|
====================================================
           당신은 던전의 전설이 되어 돌아왔습니다!");
            Console.ResetColor(); Console.ReadKey();
        }
    }
}