using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinimalAndMaximal
{
    class FindMinimalAndMaximal
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n > 0)
            {
                Console.WriteLine("Enter the integer sequence");
                int x = Convert.ToInt32(Console.ReadLine());

                int minimal = x, maximal = x;
                for (int i = 1; i < n; ++i)
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x < minimal)
                    {
                        minimal = x;
                    }
                    if (x > maximal)
                    {
                        maximal = x;
                    }
                }
                Console.WriteLine("Minimal value: {0}\nMaximal value: {1}", minimal, maximal);
            }
            else
            {
                Console.WriteLine("The sequence is empty.");
            }
        }
    }
}
