using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisableByFive
{
    class DivisableByFive
    {
        static void Main(string[] args)
        {
            int leftBoundary = Convert.ToInt32(Console.ReadLine());
            int rightBoundary = Convert.ToInt32(Console.ReadLine());

            if (leftBoundary > rightBoundary)
            {
                int tmp = rightBoundary;
                rightBoundary = leftBoundary;
                leftBoundary = tmp;
            }

            int divisableNumbersCount = 0;
            for (int i = leftBoundary; i <= rightBoundary; ++i)
            {
                if (i % 5 == 0)
                {
                    divisableNumbersCount++;
                }
            }

            Console.WriteLine(divisableNumbersCount);
                
        }
    }
}
