using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal3By3SquareSum
{
    class Maximal3By3SquareSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n + 1, m + 1];
            int[,] sum = new int[n + 1, m + 1];
            for (int i = 1; i <= n; ++i)
            {
                for (int j = 1; j <= m; ++j)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                    sum[i, j] = matrix[i, j] + sum[i - 1, j] + sum[i, j - 1] - sum[i - 1, j - 1];
                }
            }

            int maximalSum = sum[3, 3];
            int startRow = 1, startCol = 1;
            int tmpSum = 0;

            for (int i = 3; i <= n; ++i)
            {
                for (int j = 3; j <= m; ++j)
                {
                    tmpSum = sum[i, j] - sum[i - 3, j] - sum[i, j - 3] + sum[i - 3, j - 3];

                    if (tmpSum > maximalSum)
                    {
                        startRow = i - 2;
                        startCol = j - 2;
                        maximalSum = tmpSum;
                    }
                }
            }

            for (int i = startRow; i <= startRow + 2; ++i)
            {
                for (int j = startCol; j <= startCol + 2; ++j)
                {
                    if (j != startCol)
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
