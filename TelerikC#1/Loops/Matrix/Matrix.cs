using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (j > 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(i + j);
                }
                Console.Write("\n");
            }
        }
    }
}
