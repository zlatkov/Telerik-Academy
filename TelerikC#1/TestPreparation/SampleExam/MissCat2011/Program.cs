using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissCat2011
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] quantity = new int[11];

            int tmp;
            int maxValueIndex = 1;

            for (int i = 1; i <= 10; ++i)
            {
                quantity[i] = 0;
            }

            for (int i = 0; i < n; ++i)
            {
                tmp = int.Parse(Console.ReadLine());
                quantity[tmp]++;
            }

            for (int i = 2; i <= 10; ++i)
            {
                if (quantity[i] > quantity[maxValueIndex])
                {
                    maxValueIndex = i;
                }
            }

            Console.WriteLine(maxValueIndex);
        }
    }
}
