using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiral
{
    class Spiral
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] spiral = new int[n, n];

            int[] deltaX = new int[] { 0, 1, 0, -1 };
            int[] deltaY = new int[] { 1, 0, -1, 0 };

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    spiral[i, j] = -1;
                }
            }

            int currentNumber = 1;
            int coordinateMovementIndex = 0;
            int currentX = 0, currentY = 0;
            int nextX, nextY;

            while (currentNumber <= n * n)
            {
                spiral[currentX, currentY] = currentNumber++;


                nextX = currentX + deltaX[coordinateMovementIndex];
                nextY = currentY + deltaY[coordinateMovementIndex];

                while (currentNumber <= n * n && (nextX < 0 || nextX >= n || nextY < 0 || nextY >= n || spiral[nextX, nextY] != -1))
                {
                    coordinateMovementIndex = (coordinateMovementIndex + 1) % 4;

                    nextX = currentX + deltaX[coordinateMovementIndex];
                    nextY = currentY + deltaY[coordinateMovementIndex];
                }
                
                currentX = nextX;
                currentY = nextY;
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (j > 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(spiral[i, j]);
                }
                Console.Write('\n');
            }

        }
    }
}
