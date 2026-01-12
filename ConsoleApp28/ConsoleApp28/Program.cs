using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for(int i = 1; i <= 3; i++)
            //{
            //    for(int j = 1; j <= 3; j++)
            //    {
            //        Console.WriteLine($"i:{i}  j:{j}");
            //    }
            //    Console.WriteLine();
            //}
            Console.OutputEncoding = Encoding.UTF8;
            //for (int i = 0; i <= 2; i++)
            //{
            //    for(int j = 0; j <= 2; j++)
            //    {
            //        Console.Write("⬜");
            //    }
            //    Console.WriteLine();
            //}
            //for (int i = 1; i < 4; i++)
            //{
            //    for (int j = 1; j < 4; j++)
            //    {
            //        Console.Write($"{j} ");
            //    }
            //    Console.WriteLine();

            //}

            //for (int i = 0; i <= 2; i++)
            //{
            //    for(int j = 0; j <= 2; j++)
            //    {
            //        Console.Write($"({j}, {i}) ");
            //    }
            //    Console.WriteLine();
            //}

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j <= i)
                    {
                        Console.Write("*");

                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");


            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        if(j >= i)
            //        {
            //            Console.Write("*");

            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("");


            //for (int i = 5; i >= 0; i--)
            //{
            //    for (int j = 0; j <= 5; j++)
            //    {
            //        if (j <= i)
            //        {
            //            Console.Write(" ");
            //        }
            //        else
            //        {
            //            Console.Write("*");
            //        }
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine("");


            //for (int i = 5; i >= 0; i--)
            //{
            //    for (int j = 0; j <= 5; j++)
            //    {
            //        if (j < i)
            //        {
            //            Console.Write("*");
            //        }
            //        else
            //        {
            //            Console.Write(" ");
            //        }
            //    }
            //    Console.WriteLine();
            //}


            //for( int i = 1; i <= 9; i++ )
            //{
            //    for ( int j = 1; j <= 9; j++)
            //    {
            //        Console.Write($"{i}x{j} = {i * j}  ");
            //    }
            //    Console.WriteLine();
            //}
            //=== 예제 9: 미니 게임 맵 ===
            //🏠 🟩 🟩 🟩
            //🟩 🟩 🟩 🟩
            //🟩 🟩 🟩 🟩
            //🟩 🟩 🟩 🎯

            for ( int i = 0; i < 4; i++)
            {
                for( int j = 0; j < 4; j++)
                {
                    if ( j == 0  && i == 0)
                    {
                        Console.Write("🏠 ");
                    }
                    else if( j == 3 && i == 3 ) 
                    {
                            Console.Write("🎯 ");
                    }
                    else
                    {
                        Console.Write("🟩 ");

                    }
                }
                Console.WriteLine();
            }


        }
    }
}
