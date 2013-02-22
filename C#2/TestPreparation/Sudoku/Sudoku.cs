using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Sudoku
    {
        static int[,] grid = new int[9, 9];
        static int[] rowValues = new int[9];
        static int[] colValues = new int[9];
        static int[,] squareValues = new int[3, 3];

        static bool solved = false;

        static void SetValue(int x, int y, int value)
        {
            grid[x, y] = value;
            rowValues[x] ^= 1 << value;
            colValues[y] ^= 1 << value;
            squareValues[x / 3, y / 3] ^= 1 << value;
        }

        static void RemoveValue(int x, int y, int value)
        {
            grid[x, y] = 0;
            rowValues[x] ^= 1 << value;
            colValues[y] ^= 1 << value;
            squareValues[x / 3, y / 3] ^= 1 << value;
        }

        static bool ValidValue(int x, int y, int value)
        {
            return ((rowValues[x] & (1 << value)) == 0 &&
                     (colValues[y] & (1 << value)) == 0 &&
                     (squareValues[x / 3, y / 3] & (1 << value)) == 0);
        }

        static void Solve(int x, int y)
        {
            if (solved)
            {
                return;
            }
            if (x == 9)
            {
                solved = true;
                return;
            }
            else
            {
                if (grid[x, y] != 0)
                {
                    if (y == 8)
                    {
                        Solve(x + 1, 0);
                    }
                    else
                    {
                        Solve(x, y + 1);
                    }
                }
                else
                {
                    for (int i = 1; i <= 9; ++i)
                    {
                        if (ValidValue(x, y, i))
                        {
                            SetValue(x, y, i);
                            if (y == 8)
                            {
                                Solve(x + 1, 0);
                            }
                            else
                            {
                                Solve(x, y + 1);
                            }
                            if (solved)
                            {
                                return;
                            }
                            else
                            {
                                RemoveValue(x, y, i);
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 9; ++i)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 9; ++j)
                {
                    if (line[j] >= '0' && line[j] <= '9')
                    {
                        SetValue(i, j, (int)(line[j] - '0'));
                    }
                }
            }

            Solve(0, 0);

            for (int i = 0; i < 9; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    Console.Write(grid[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
