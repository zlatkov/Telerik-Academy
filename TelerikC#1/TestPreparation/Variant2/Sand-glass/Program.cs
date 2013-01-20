using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sand_glass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int skip = 0;
            int left = n;
            int coef = -1;

            for (int i = 1; i <= n; ++i)
            {
                int tmp = left;
                for (int j = 1; j <= n; ++j)
                {
                    if (j > skip && tmp > 0)
                    {
                        Console.Write("*");
                        tmp--;
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.Write("\n");
                if (left == 1)
                {
                    coef *= -1;
                }

                left += coef * 2;
                skip += -1 * coef;
            }
        }
    }
}
