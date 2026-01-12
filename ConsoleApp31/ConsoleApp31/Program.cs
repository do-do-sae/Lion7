using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 설정 및 초기화
            const int targetX = 60;
            const int targetY = 20;
            int x = 5, y = 5;

            Console.SetWindowSize(80, 80);
            Console.SetBufferSize(80, 80);
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            // 2. 맵 생성 (0: 빈칸, 1: 벽)
            int[,] map = new int[80, 80];
            Random rand = new Random();
            int wallCount = 400; // 벽 개수 대폭 증가

            // --- [벽 생성 로직 수정 버전] ---
            for (int i = 0; i < wallCount; i++)
            {
                int randX = rand.Next(0, 80);
                int randY = rand.Next(0, 80);

                // [수정된 조건] 플레이어의 현재 위치(x, y)와 똑같거나 바로 옆칸이면 스킵!
                bool isNearPlayer = (randX >= x - 1 && randX <= x + 1) && (randY >= y - 1 && randY <= y + 1);

                if (isNearPlayer) continue;
                if (randX == targetX && randY == targetY) continue;

                map[randX, randY] = 1;
            }

            // 3. 게임 루프
            while (true)
            {
                // [꿀팁] Clear를 매번 하면 번쩍거림이 심하므로, 
                // 지금은 학습 단계이니 그대로 유지하되 나중에 '부분 그리기'를 배우면 좋습니다.
                Console.Clear();

                // 벽 그리기
                for (int j = 0; j < 80; j++)
                {
                    for (int i = 0; i < 80; i++)
                    {
                        if (map[i, j] == 1)
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write("■");
                        }
                    }
                }

                // 목적지 표시
                Console.SetCursorPosition(targetX, targetY);
                Console.ForegroundColor = ConsoleColor.Yellow; // 목적지 강조
                Console.Write("🏠");
                Console.ResetColor();

                // 플레이어 표시
                Console.SetCursorPosition(x, y);
                Console.Write("★");
                Console.ResetColor();

                // 승리 조건 체크
                if (x == targetX && y == targetY)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n축하합니다! 집에 무사히 도착했습니다!");
                    break;
                }

                // 키 입력 처리
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (y > 0 && map[x, y - 1] == 0) y--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (y < 77 && map[x, y + 1] == 0) y++;
                        break;
                    case ConsoleKey.LeftArrow:
                        // x가 2만큼 줄어든 위치에 벽(1)이 있는지 확인
                        if (x >= 2 && map[x - 2, y] == 0) x -= 2;
                        break;

                    case ConsoleKey.RightArrow:
                        // x가 2만큼 늘어난 위치에 벽(1)이 있는지 확인
                        if (x <= 77 && map[x + 2, y] == 0) x += 2;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }
    }
}