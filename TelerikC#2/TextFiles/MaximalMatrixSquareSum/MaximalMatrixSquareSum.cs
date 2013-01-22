using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace MaximalMatrixSquareSum
{
    class MaximalMatrixSquareSum
    {
        static int CalculateMaximalSum(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int maxSum = int.MinValue;
            int tmpSum = 0;

            for (int i = 0; i < n - 1; ++i)
            {
                for (int j = 0; j < n - 1; ++j)
                {
                    tmpSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (tmpSum > maxSum)
                    {
                        maxSum = tmpSum;
                    }
                }
            }

            return maxSum;
        }

        static void Main(string[] args)
        {
            string inputFileName = Console.ReadLine();
            string outputFileName = Console.ReadLine();

            try
            {
                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    int n = int.Parse(reader.ReadLine());

                    int[,] matrix = new int[n, n];

                    for (int i = 0; i < n; ++i)
                    {
                        string line = reader.ReadLine();
                        string[] numbers = line.Split(' ');

                        for (int j = 0; j < n; ++j)
                        {
                            matrix[i, j] = int.Parse(numbers[j]);
                        }
                    }

                    int maximalSum = CalculateMaximalSum(matrix);
                    using (StreamWriter wrtier = new StreamWriter(outputFileName))
                    {
                        wrtier.WriteLine(maximalSum);
                    }
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
