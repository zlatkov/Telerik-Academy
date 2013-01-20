using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatestOfFiveVariables
{
    class GreatestOfFiveVariables
    {
        static void Main(string[] args)
        {
            int greatest = 0;
            int tmp;

            for (int i = 0; i < 5; ++i)
            {
                tmp = Convert.ToInt32(Console.ReadLine());
                if (i == 0)
                {
                    greatest = tmp;
                }
                else
                {
                    greatest = Math.Max(greatest, tmp);
                }
            }

            Console.WriteLine(greatest);
        }
    }
}
