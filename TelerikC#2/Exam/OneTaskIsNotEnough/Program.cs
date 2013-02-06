using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaskIsNotEnough
{
    class Program
    {
        static int SolveLamps(int x)
        {
            bool[] marked = new bool[x + 1];
            int incr = 2, markedCount = 0; 
            int lastStartPos = 1;

            while (true)
            {
                if (markedCount == x)
                {
                    break;
                }

                int startPos = 1;
                while (startPos <= x && marked[startPos])
                {
                    ++startPos;
                }

                lastStartPos = startPos;
                while (startPos <= x)
                {
                    if (marked[startPos])
                    {
                        break;
                    }
                    marked[startPos] = true;
                    markedCount++;

                    int cnt = 0;
                    for (int i = startPos + 1; i <= x; ++i)
                    {
                        if (!marked[i])
                        {
                            cnt++;
                        }
                        if (cnt == incr)
                        {
                            startPos = i;
                            break;
                        }
                    }
                }
                incr++;
            }

            return lastStartPos;
        }

        static string SolveRobot(string sequence)
        {
            int[] dx = { 1, 0,-1, 0 };
            int[] dy = { 0, 1, 0, -1 };
            int pos = 0;

            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;
            bool grow = false;

            int cx = 0, cy = 0;
            for (int k = 0; k < 3; ++k)
            {
                grow = false;
                for (int i = 0; i < sequence.Length; ++i)
                {
                    if (minX > cx)
                    {
                        grow = true;
                        minX = cx;
                    }
                    if (minY > cy)
                    {
                        grow = true;
                        minY = cy;
                    }
                    if (maxX < cx)
                    {
                        grow = true;
                        maxX = cx;
                    }
                    if (maxY < cy)
                    {
                        grow = true;
                        maxY = cy;
                    }


                    if (sequence[i] == 'S')
                    {
                        cx += dx[pos];
                        cy += dy[pos];
                    }
                    else if (sequence[i] == 'L')
                    {
                        pos = (pos + 1) % 4;
                    }
                    else
                    {
                        pos = pos - 1;
                        if (pos < 0)
                        {
                            pos = 3;
                        }
                    }
                }
            }

            if (grow == false)
            {
                return "bounded";
            }
            else
            {
                return "unbounded";
            }
            
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           string commandSequence1 = Console.ReadLine();
            string commandSequence2 = Console.ReadLine();

            Console.WriteLine(SolveLamps(n));
            Console.WriteLine(SolveRobot(commandSequence1));
            Console.WriteLine(SolveRobot(commandSequence2));
        }
    }
}
