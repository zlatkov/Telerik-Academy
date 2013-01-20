using System;
using System.Linq;

namespace FillMatrixD
{
    class FillMatrixD
    {
        static bool ValidCell(int x, int y, int n)
        {
            return (x >= 0 && x < n && y >= 0 && y < n);
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] deltaX = new int[] {1, 0, -1,  0};
            int[] deltaY = new int[] {0, 1,  0, -1};
            
            int[,] matrix = new int[n, n];
            int value = 1;

            int direction = 0;
            int currentX = 0, currentY = 0;
            int nextX = 0, nextY = 0;

            while (value <= n * n)
            {
                matrix[currentX, currentY] = value++;
                for (int i = 0; i < 2; ++i)
                {
                    nextX = currentX + deltaX[(direction + i) % 4];
                    nextY = currentY + deltaY[(direction + i) % 4];

                    if (ValidCell(nextX, nextY, n) && matrix[nextX, nextY] == 0)
                    {
                        currentX = nextX;
                        currentY = nextY;
                        direction = (direction + i) % 4;
                        break;
                    }
                }
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (j > 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(matrix[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
