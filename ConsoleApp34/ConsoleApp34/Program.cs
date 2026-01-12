using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34
{
    internal class Program
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch(); //c언어 함수 가져옴
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            string[] player = new string[]
            {
                "->",
                ">>>",
                "->"
            }; //배열 문자열로 그리기


            int[] miX = new int[100];
            int[] miY = new int[100];
            bool[] miActive = new bool[100]; // 미사일이 날아가는 중인지 체크 (상태표)

            int playerX = 0;
            int playerY = 12;

            ConsoleKeyInfo keyinfo; //키정보

            Console.CursorVisible = false; //콘솔창 커서 안보이게하기

            //Sleep() 1000 : 1초동안 프로그램 잠시 멈춤
            //지연 방법 시간을 계산해서 1초 루프
            int dwTime = Environment.TickCount; // 1/1000 초가 흐릅니다.
            
            
            while (true)
            {
                //1초 루프
                if (dwTime + 1 < Environment.TickCount)
                {
                    //현재 시간 세팅
                    dwTime = Environment.TickCount;

                    Console.Clear();
                    //키 영역
                    int pressKey; //정수형 변수 선언 키값 받을거임

                    if(Console.KeyAvailable) //키가 눌렸는지 체크
                    {
                        pressKey = _getch(); //아스키값 왼쪽 오른쪽

                        switch(pressKey)
                        {
                            case 72:  //위쪽방향 아스키코드                    
                                playerY--;
                                if (playerY < 1)
                                    playerY = 1;
                                break;
                            case 75:
                                //왼쪽 화살표키
                                playerX--;
                                if (playerX < 0)
                                    playerX = 0;
                                break;
                            case 77:
                                //오른쪽
                                playerX++;
                                if (playerX > 75)
                                    playerX = 75;
                                break;
                            case 80: //아래
                                playerY++;
                                if (playerY > 21)
                                    playerY = 21;
                                break;
                            case 32: // 스페이스바
                                for (int i = 0; i < 100; i++)
                                {
                                    if (miActive[i] == false) // 발사 안 된 빈 칸 발견!
                                    {
                                        miActive[i] = true;   // 발사 상태로 변경
                                        miX[i] = playerX + 1; // 현재 플레이어 위치 복사
                                        miY[i] = playerY + 1;
                                        break; // 한 발 쐈으니 for문 탈출
                                    }
                                }
                                break;
                        }
                    }

                    for (int i = 0; i < player.Length; i++)
                    {
                        //콘솔좌표 설정 플레이어X 플레이어Y
                        Console.SetCursorPosition(playerX, playerY + i);
                        //문자열배열 출력
                        Console.WriteLine(player[i]);
                        
                    }
                    // --- while문 안쪽, switch문 아래에 넣어주세요 ---
                    for (int i = 0; i < 100; i++)
                    {
                        if (miActive[i] == true) // 날아가고 있는 미사일만 처리
                        {
                            // 1. 현재 위치 지우기 (미사일 잔상 삭제)
                            Console.SetCursorPosition(miX[i], miY[i]);
                            Console.Write("  ");

                            // 2. 좌표 앞으로 이동
                            miX[i]++;

                            // 3. 화면 끝(75)에 안 닿았으면 그리기
                            if (miX[i] < 75)
                            {
                                Console.SetCursorPosition(miX[i], miY[i]);
                                Console.Write("->");
                            }
                            else
                            {
                                // 4. 화면 끝에 닿으면 다시 발사 가능한 상태로 초기화
                                miActive[i] = false;
                            }
                        }
                    }

                }
            }








        }
    }
}
