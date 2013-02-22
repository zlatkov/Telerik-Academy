using System;
using System.Linq;

namespace FillMatrixA
{
    class FillMatrixA
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            for (int j = 0; j < n; ++j)
            {
                for (int i = 0; i < n; ++i)
                {
                    matrix[i, j] = j * n + i + 1;
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
