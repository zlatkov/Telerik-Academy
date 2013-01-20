using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rows = new int[8];

            for (int i = 0; i < 8; ++i)
            {
                rows[i] = int.Parse(Console.ReadLine());
            }

            int maximalLength = 0;
            int occurrences = 0;

            for (int i = 0; i < 8; ++i)
            {
                int tmpLength = 0;
                for (int j = 0; j < 8; ++j)
                {
                    if (((rows[i] >> j) & 1) > 0)
                    {
                        tmpLength++;

                        if (tmpLength > maximalLength)
                        {
                            maximalLength = tmpLength;
                            occurrences = 1;
                        }
                        else if (tmpLength == maximalLength)
                        {
                            occurrences++;
                        }
                    }
                    else
                    {
                        tmpLength = 0;
                    }
                }
            }

            for (int j = 0; j < 8; ++j)
            {
                int tmpLength = 0;
                for (int i = 0; i < 8; ++i)
                {
                    if (((rows[i] >> j) & 1) > 0)
                    {
                        tmpLength++;

                        if (tmpLength > maximalLength)
                        {
                            maximalLength = tmpLength;
                            occurrences = 1;
                        }
                        else if (tmpLength == maximalLength)
                        {
                            occurrences++;
                        }
                    }
                    else
                    {
                        tmpLength = 0;
                    }
                }
            }

            if (maximalLength == 1)
            {
                occurrences >>= 1;
            }

            Console.WriteLine(maximalLength + "\n" + occurrences);
        }
    }
}
