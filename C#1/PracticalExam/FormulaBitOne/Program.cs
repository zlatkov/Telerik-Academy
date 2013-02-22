using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
2
38
20
48
111
15
3
43
 */

namespace FormulaBitOne
{
    class Program
    {
        static bool IsValid(int x, int y)
        {
            return x >= 0 && x < 8 && y >= 0 && y < 8;
        }
        static void Main(string[] args)
        {
            byte[] grid = new byte[8];
            for (int i = 0; i < 8; ++i)
            {
                grid[i] = byte.Parse(Console.ReadLine());
            }

            int[] dx = new int[] { 1, 0, -1, 0 };
            int[] dy = new int[] { 0, 1, 0,  1 };

            int currentX = 0;
            int currentY = 0;

            int pathLength = 0;
            int numberTurns = 0;

            int currentPos = 0;

            while (((grid[currentX] >> currentY) & 1) == 0)
            {
                pathLength++;
                if (currentX == 7 && currentY == 7)
                {
                    break;
                }

                if (IsValid(currentX + dx[currentPos], currentY + dy[currentPos]) && 
                    ((grid[currentX + dx[currentPos]] >> currentY + dy[currentPos]) & 1) == 0)
                {
                    currentX += dx[currentPos];
                    currentY += dy[currentPos];
                }
                else
                {
                    currentPos = (currentPos + 1) % 4;
                    if (IsValid(currentX + dx[currentPos], currentY + dy[currentPos]) &&
                    ((grid[currentX + dx[currentPos]] >> currentY + dy[currentPos]) & 1) == 0)
                    {
                        currentX += dx[currentPos];
                        currentY += dy[currentPos];
                        numberTurns++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (currentX == 7 && currentY == 7)
            {
                Console.WriteLine(pathLength + " " + numberTurns);
            }
            else
            {
                Console.WriteLine("No " + pathLength);
            }
        }
    }
}
