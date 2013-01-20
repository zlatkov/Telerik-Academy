using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillMatrixB
{
    class FillMatrixB
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int value = 1;
            for (int j = 0; j < n; ++j)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < n; ++i)
                    {
                        matrix[i, j] = value++;
                    }
                }
                else
                {
                    for (int i = n - 1; i >= 0; --i)
                    {
                        matrix[i, j] = value++;
                    }
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
