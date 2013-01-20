using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSumZero
{
    class SubsetSumZero
    {
        static void Main(string[] args)
        {
            int[] x = new int[5];
            for (int i = 0; i < 5; ++i)
            {
                x[i] = Convert.ToInt32(Console.ReadLine());
            }

            int sum;
            bool zeroSumFound = false;

            for (int mask = 1; mask < (1 << 5); ++mask)
            {
                sum = 0;
                for (int i = 0; i < 5; ++i)
                {
                    if ((mask & (1 << i)) > 0)
                    {
                        sum += x[i];
                    }
                }

                if (sum == 0)
                {
                    Console.WriteLine("There exists subset which sums to zero.");
                    zeroSumFound = true;
                    break;
                }
            }

            if (!zeroSumFound)
            {
                Console.WriteLine("No such subset is found.");
            }
        }
    }
}
