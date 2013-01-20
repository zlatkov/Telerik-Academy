using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pillars
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] columnBitSum = new int[8];

            for (int i = 0; i < 8; ++i)
            {
                columnBitSum[i] = 0;
            }

            for (int i = 0; i < 8; ++i)
            {
                int x = int.Parse(Console.ReadLine());
                for (int j = 0; j < 8; ++j)
                {
                    columnBitSum[j] += (x >> j) & 1;
                }
            }

            for (int i = 1; i < 8; ++i)
            {
                columnBitSum[i] += columnBitSum[i - 1];
            }

            bool found = false;
            int foundIndex = 0, foundCount = 0;

            if (columnBitSum[7] == 0)
            {
                foundIndex = 7;
                found = true;
            }
            else if (columnBitSum[7] - columnBitSum[0] == 0)
            {
                foundIndex = 0;
                found = true;
            }
            else
            {
                for (int i = 7; i > 0; --i)
                {
                    if (columnBitSum[i - 1] == columnBitSum[7] - columnBitSum[i])
                    {
                        foundIndex = i;
                        foundCount = columnBitSum[i - 1];
                        found = true;
                        break;
                    }
                }
            }

            if (found)
            {
                Console.WriteLine(foundIndex);
                Console.WriteLine(foundCount);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
