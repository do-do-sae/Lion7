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
            return $"[{(new string('■', filledLength))}{(new string('□', barLength - filledLength))}] {HP}/{MaxHP}";
        }
    }

    class Program
    {
        static int startingRelics = 0;  
        static int mapSize = 40;
        static int playerX = 0, playerY = 0;
        static int exitX = 39, exitY = 39;
        static int shopX, shopY;
        static char[,] map = new char[40, 40];
        static bool[,] traps = new bool[40, 40];
        static bool[,] items = new bool[40, 40];
        static string[,] itemType = new string[40, 40];

        static Unit player;
        static Random rand = new Random();
        static int gold = 0;
        static int exLevel = 0;  
        static int moonLevel = 0; 
        static int mystLevel = 0; 
        static int dungeonLevel = 1;

        static int totalKills = 0;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "던전 탈출: 업적 & 상점 통합 에디션";
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
                    Console.WriteLine(" 1. 다음 깊은 곳으로 도전 (HP 회복)");
                    Console.WriteLine(" 2. 던전 탈출하기 (성적표 확인)");
                    Console.Write(" 선택: ");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        dungeonLevel++;
                        player.HP = player.MaxHP;
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        ShowFinalResult(true);
                        break;
                    }
                }
                else
                {
                    ShowGameOver();
                    ShowFinalResult(false);
                    break;
                }
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

            do
            {
                shopX = rand.Next(5, 35);
                shopY = rand.Next(5, 35);
            } while (map[shopY, shopX] == '#');

            int mCount = 0;
            while (mCount < 50)
            {
                int rx = rand.Next(0, mapSize), ry = rand.Next(0, mapSize);
                if (map[ry, rx] == '#' || (rx == playerX && ry == playerY) || (rx == exitX && ry == exitY) || (rx == shopX && ry == shopY)) continue;
                traps[ry, rx] = true; mCount++;
            }

            string[] treasures = { "엑스칼리버", "월광", "미스틸테인" };
            int iCount = 0;
            while (iCount < 20)
            {
                int rx = rand.Next(0, mapSize), ry = rand.Next(0, mapSize);
                if (map[ry, rx] == '#' || traps[ry, rx] || items[ry, rx] || (rx == shopX && ry == shopY)) continue;
                items[ry, rx] = true;
                itemType[ry, rx] = (iCount < 9) ? treasures[iCount % 3] : "포션";
                iCount++;
            }
        }

        static void DrawMapFast()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (i == playerY && j == playerX) { Console.ForegroundColor = ConsoleColor.Green; Console.Write("P "); }
                    else if (i == exitY && j == exitX) { Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("E "); }
                    else if (i == shopY && j == shopX) { Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("S "); }
                    else if (map[i, j] == '#') { Console.ForegroundColor = ConsoleColor.White; Console.Write("# "); }
                    else if (items[i, j]) { Console.ForegroundColor = ConsoleColor.Blue; Console.Write("? "); }
                    else if (traps[i, j]) { Console.ForegroundColor = ConsoleColor.Red; Console.Write("M "); }
                    else { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(". "); }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static void PrintStatus()
        {
            Console.WriteLine($"\n[LV.{dungeonLevel}] {player.Name} 상태: {player.GetHealthBar()} | 골드: {gold}G");
            Console.Write("보유 유물: ");
            if (exLevel > 0) { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write($"[⚔️ +{exLevel}] "); }
            if (moonLevel > 0) { Console.ForegroundColor = ConsoleColor.Blue; Console.Write($"[❄️ +{moonLevel}] "); }
            if (mystLevel > 0) { Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($"[⚡ +{mystLevel}] "); }
            Console.ResetColor();
            Console.WriteLine($"\n처치 수: {totalKills} | WASD: 이동 | S: 상점, #: 벽, ?: 아이템, M: 몬스터");
        }

        static void MovePlayer(ConsoleKeyInfo key)
        {
            int nx = playerX, ny = playerY;
            if (key.Key == ConsoleKey.W) ny--;
            else if (key.Key == ConsoleKey.S) ny++;
            else if (key.Key == ConsoleKey.A) nx--;
            else if (key.Key == ConsoleKey.D) nx++;
            if (nx >= 0 && nx < mapSize && ny >= 0 && ny < mapSize && map[ny, nx] != '#') { playerX = nx; playerY = ny; }
        }

        static void CheckEvent()
        {
            // 1. 상점 이벤트
            if (playerX == shopX && playerY == shopY)
            {
                OpenShop();
                Console.Clear();
            }

            if (items[playerY, playerX])
            {
                Console.SetCursorPosition(0, mapSize + 5);
                string t = itemType[playerY, playerX];

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n========================================");

                if (t == "포션")
                {
                    player.HP = Math.Min(player.MaxHP, player.HP + 50);
                    Console.WriteLine($" [!] 반짝이는 액체가 든 포션을 마셨습니다!");
                    Console.WriteLine($" [!] 체력이 50 회복되었습니다. (현재: {player.HP}/{player.MaxHP})");
                }
                else
                {
                    if (t == "엑스칼리버") exLevel++;
                    else if (t == "월광") moonLevel++;
                    else if (t == "미스틸테인") mystLevel++;

                    if (dungeonLevel == 1) startingRelics++;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" [★] 고대의 유물 [{t}]을(를) 발견했습니다!");
                    Console.WriteLine($" [!] {t}의 레벨이 상승했습니다! (현재: +{GetLevel(t)})");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("========================================");
                Console.WriteLine(" 계속하려면 아무 키나 누르세요...");

                items[playerY, playerX] = false;
                Console.ReadKey(true);         
                Console.Clear();                 
            }

            if (traps[playerY, playerX])
            {
                if (StartBattle()) traps[playerY, playerX] = false;
                Console.Clear();
            }
        }

        static int GetLevel(string name)
        {
            if (name == "엑스칼리버") return exLevel;
            if (name == "월광") return moonLevel;
            if (name == "미스틸테인") return mystLevel;
            return 0;
        }

        static void OpenShop()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("====================================================");
                Console.WriteLine("             🛒 신비한 던전 상점 (S)                ");
                Console.WriteLine("====================================================");
                Console.ResetColor();
                Console.WriteLine($" 현재 보유 골드: {gold} G");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine(" 1. 빨간 포션 (HP 50 회복)      - 30 G");
                Console.WriteLine(" 2. 생명의 보석 (최대 HP +30)   - 50 G");
                Console.WriteLine(" 3. 랜덤 무기 강화 주문서       - 150 G");
                Console.WriteLine(" 0. 상점 나가기");
                Console.WriteLine("----------------------------------------------------");
                Console.Write(" 선택: ");

                string choice = Console.ReadLine();
                string message = "";
                ConsoleColor msgColor = ConsoleColor.White;

                if (choice == "0") break;

                if (choice == "1" && gold >= 30)
                {
                    player.HP = Math.Min(player.MaxHP, player.HP + 50);
                    gold -= 30;
                    message = $"[!] 포션을 사용했습니다! 체력이 50 회복되었습니다. (현재: {player.HP}/{player.MaxHP})";
                    msgColor = ConsoleColor.Cyan;
                }
                else if (choice == "2" && gold >= 50)
                {
                    player.MaxHP += 30;
                    player.HP += 30;
                    gold -= 50;
                    message = $"[!] 최대 체력이 증가했습니다! (현재 MaxHP: {player.MaxHP})";
                    msgColor = ConsoleColor.Green;
                }
                else if (choice == "3" && gold >= 150)
                {
                    int r = rand.Next(3);
                    string upgradedWeapon = "";
                    if (r == 0) { exLevel++; upgradedWeapon = "엑스칼리버"; }
                    else if (r == 1) { moonLevel++; upgradedWeapon = "월광"; }
                    else { mystLevel++; upgradedWeapon = "미스틸테인"; }
                    gold -= 150;
                    message = $"[★] 강화 성공! [{upgradedWeapon}]의 레벨이 올랐습니다! (+{GetLevel(upgradedWeapon)})";
                    msgColor = ConsoleColor.Yellow;
                }
                else if (gold < 30) 
                {
                    message = "[X] 골드가 부족하여 물건을 살 수 없습니다...";
                    msgColor = ConsoleColor.Red;
                }
                else
                {
                    message = "[?] 잘못된 선택입니다.";
                    msgColor = ConsoleColor.Gray;
                }

                if (message != "")
                {
                    Console.WriteLine("\n----------------------------------------------------");
                    Console.ForegroundColor = msgColor;
                    Console.WriteLine($" {message}");
                    Console.ResetColor();
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine(" 아무 키나 누르면 상점 메뉴로 돌아갑니다.");
                    Console.ReadKey(true);
                }
            }
        }

        static void DrawEntity(string name)
        {
            if (name == "고블린")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
              _  _
             ( \_/ )         [ 교활한 고블린 ]
            / @   @ \         
           ( >  0  < )       ""키키킥.. 인간이다!""
            \_______/         
            /   |   \
           /|   |   |\
            |_|___|_|
            /_|   |_\");
            }
            else if (name == "강철 골렘")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(@"
             _________
            /         \      [ 거대 강철 골렘 ]
           |  [O] [O]  |     
           |   _____   |     ""부-우-웅...""
           |  |_____|  |      
           \___________/
           /           \
          /|           |\
         /_|___________|_\
            |____|____|");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"
                  __    __
                 /  \  /  \    [ 드래곤 ]
            _____/ __ \/ __ \_____
           /      \  /  \  /      \   
          |  (X)   \/    \/  (X)  |   ""네 무덤이 될 것이다!""
           \      /      \       /      
            \____/  ____  \____ /
             /    \/    \/    \
            /   \__________/   \
           /       /    \       \");
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

      
            bool isFrozen = false;   
            int shockDamage = 0;      

            while (!player.IsDead && !monster.IsDead)
            {
                Console.Clear();
                Console.WriteLine($"======================= {dungeonLevel}층 전투 =======================");
                DrawEntity(monster.Name);
                Console.WriteLine("=========================================================");
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($" [플레이어] {player.Name} : {player.GetHealthBar()}");
                Console.ForegroundColor = (monster.Name == "고블린") ? ConsoleColor.Green : (monster.Name == "강철 골렘") ? ConsoleColor.Gray : ConsoleColor.Red;
                Console.WriteLine($" [적] {monster.Name} : {monster.GetHealthBar()}");
                Console.ResetColor();

                if (shockDamage > 0) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($" [상태] 감전 데미지 중첩: {shockDamage}"); Console.ResetColor(); }
                if (isFrozen) { Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(" [상태] 적이 빙결되었습니다! (행동 불능)"); Console.ResetColor(); }

                Console.WriteLine("=========================================================");
                Console.WriteLine($" 상황: {log}");
                Console.WriteLine("---------------------------------------------------------");
                PrintTypeChart();
                PrintSkillMenu(1, "크게베기 (치명타 15%)", exLevel, 30 + (exLevel * 50), ConsoleColor.DarkGray);
                PrintSkillMenu(2, "얼음화살 (빙결)", moonLevel, 20 + (moonLevel * 5), ConsoleColor.Blue);
                PrintSkillMenu(3, "라이트닝 (감전 중첩)", mystLevel, 5 + (mystLevel * 10), ConsoleColor.Yellow);

                Console.Write("\n 행동 선택: ");
                string c = Console.ReadLine();
                int baseDamage = 0;
                string skillType = "";

                if (c == "1") { baseDamage = 30 + (exLevel * 50); skillType = "Slash"; }
                else if (c == "2") { baseDamage = 25 + (moonLevel * 40); skillType = "Ice"; }
                else if (c == "3") { baseDamage = 50 + (mystLevel * 70); skillType = "Light"; }
                else continue;

                float multiplier = 1.0f;
                if (monster.Name == "고블린") { if (skillType == "Ice") multiplier = 1.5f; if (skillType == "Light") multiplier = 0.5f; }
                else if (monster.Name == "강철 골렘") { if (skillType == "Light") multiplier = 1.5f; if (skillType == "Slash") multiplier = 0.5f; }
                else if (monster.Name == "심연의 드래곤") { if (skillType == "Slash") multiplier = 1.5f; if (skillType == "Ice") multiplier = 0.5f; }

                int finalDamage = (int)(baseDamage * multiplier);
                string effectLog = "";

             
                if (skillType == "Slash")
                {
                    if (rand.Next(0, 100) < 15) { finalDamage *= 2; effectLog = " [치명타 터짐!!]"; }
                }
                else if (skillType == "Ice") 
                {
                    if (rand.Next(0, 100) < 10 + (moonLevel * 5)) { isFrozen = true; effectLog = " [빙결 성공!]"; }
                }
                else if (skillType == "Light") 
                {
                    int stack = 5 + (mystLevel * 10);
                    shockDamage += stack;
                    effectLog = $" [감전 중첩 +{stack}]";
                }

                monster.HP -= finalDamage;
                log = $"{player.Name}의 {finalDamage} 데미지 공격!{effectLog}";

                if (shockDamage > 0 && !monster.IsDead)
                {
                    monster.HP -= shockDamage;
                    log += $"\n [!] 감전으로 인한 {shockDamage} 추가 피해!";
                }

                if (!monster.IsDead)
                {
                    if (isFrozen)
                    {
                        log += $"\n [!] {monster.Name}이 얼어붙어 공격하지 못합니다!";
                        isFrozen = false;
                    }
                    else
                    {
                        int md = rand.Next(15, 25) + (monster.Grade * 20) + (dungeonLevel * 10);
                        player.HP -= md;
                        log += $"\n [!] {monster.Name}의 {md} 데미지 반격!";
                    }
                }
            }

            if (player.IsDead) return false;

            totalKills++;
            int rewardGold = (monster.Grade + 1) * 30 + rand.Next(1, 20);
            gold += rewardGold;
            Console.WriteLine($"\n전투 승리! {rewardGold}G를 획득했습니다.");
            Console.ReadKey(true);
            return true;
        }

        static void PrintSkillMenu(int num, string name, int level, int damage, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($" {num}. {name} ");
            if (level > 0) Console.Write($"[Lv.{level}] ");
            else Console.Write("[기본] ");
            Console.WriteLine($"(데미지: {damage})");
            Console.ResetColor();
        }
        static void PrintTypeChart()
        {
            Console.WriteLine(" [ 몬스터 상성 가이드 ]");
            Console.WriteLine("---------------------------------------------------------");
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("고블린:   ");
            Console.ResetColor(); Console.Write("얼음 "); Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("▲(1.5배) ");
            Console.ResetColor(); Console.Write("/ 전기 "); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("▼(0.5배)");

            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Gray; Console.Write("강철골렘: ");
            Console.ResetColor(); Console.Write("전기 "); Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("▲(1.5배) ");
            Console.ResetColor(); Console.Write("/ 참격 "); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("▼(0.5배)");

            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Red; Console.Write("드래곤:   ");
            Console.ResetColor(); Console.Write("참격 "); Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("▲(1.5배) ");
            Console.ResetColor(); Console.Write("/ 얼음 "); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("▼(0.5배)");

            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------");
        }

        static void ShowGameOver()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
    ====================================================
  _____   ___  ___  ___ _____   _____  _   _  _____ ______ 
 |  __ \ / _ \ |  \/  ||  ___| |  _  || | | ||  ___|| ___ \
 | |  \// /_\ \| .  . || |__   | | | || | | || |__  | |_/ /
 | | __ |  _  || |\/| ||  __|  | | | || | | ||  __| |  / /
 | |_\ \| | | || |  | || |___  \ \_/ /\ \_/ /| |___ | |\ \      
  \____/\_| |_/\_|  |_/\_____|  \___/  \___/ \_____|\_| \_|    
    ====================================================
            ");
            Console.ResetColor(); Console.ReadKey();
        }

        static void ShowGameClear()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
====================================================
         _____  _      _____   ___  ______ 
        /  __ \| |    |  ___| / _ \ | ___ \
        | /  \/| |    | |__  / /_\ \| |_/ /
        | |    | |    |  __| |  _  ||    / 
        | \__/\| |____| |___ | | | || |\ \ 
         \____/\_____/\_____|\_| |_/\_| \_|
====================================================
       ");
            Console.ResetColor();
        }

        static void ShowFinalResult(bool escaped)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("====================================================");
            Console.WriteLine("                🎉   최종 성적표   🎉                ");
            Console.WriteLine("====================================================");
            Console.ResetColor();

            string title = "성장하는 용사";
            ConsoleColor tColor = ConsoleColor.White;

 
            if (escaped && dungeonLevel >= 5) { title = "불사신"; tColor = ConsoleColor.Cyan; }
            else if (exLevel >= 3 && moonLevel >= 3 && mystLevel >= 3) { title = "유물 수집가"; tColor = ConsoleColor.Magenta; }
            else if (gold >= 500) { title = "자산가"; tColor = ConsoleColor.Yellow; }
            else if (totalKills >= 20) { title = "학살자"; tColor = ConsoleColor.Red; }
            else if (totalKills < 5 && dungeonLevel >= 2) { title = "평화주의자"; tColor = ConsoleColor.Green; }
            else if (startingRelics >= 3) { title = "행운아"; tColor = ConsoleColor.Blue; }

            Console.Write("\n ▶ 획득 칭호: ");
            Console.ForegroundColor = tColor;
            Console.WriteLine($"[{title}]");
            Console.ResetColor();

            Console.WriteLine($" ▶ 돌파 층수: {dungeonLevel}층");
            Console.WriteLine($" ▶ 적 처치 수: {totalKills}마리");
            Console.WriteLine($" ▶ 보유 골드 : {gold} G");
            Console.WriteLine($" ▶ 유물 상태 : ⚔️+{exLevel} ❄️+{moonLevel} ⚡+{mystLevel}");
            Console.WriteLine("\n====================================================");
            Console.WriteLine("          아무 키나 누르면 종료됩니다.              ");
            Console.WriteLine("====================================================");
            Console.ReadKey();
        }
    }
}