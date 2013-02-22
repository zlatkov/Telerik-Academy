using System;
using System.Linq;

namespace FillMatrixC
{
    class FillMatrixC
    {
        static void Main(string[] args)
        {   
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            int value = 1;
            for (int i = n - 1; i >= 0; --i)
            {
                for (int j = 0; j < n - i; ++j)
                {
                    matrix[i + j, j] = value++;
                }
            }

            for (int j = 1; j < n; ++j)
            {
                for (int i = 0; i < n - j; ++i)
                {
                    matrix[i, i + j] = value++;
                }
            }

            for (int i = 0; i < n; i++)
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
