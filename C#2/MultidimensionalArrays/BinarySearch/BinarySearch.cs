using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] sequence = new int[n];
            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int k = int.Parse(Console.ReadLine());
            Array.Sort(sequence);

            int index = Array.BinarySearch(sequence, k);
            if (index >= 0)
            {
                Console.WriteLine("The found value is: {0}.", sequence[index]);
            }
            else
            {
                if (~index == n)
                {
                    Console.WriteLine("The found valus is: {0}.", sequence[n - 1]);
                }
                else if (~index > 0 && ~index < n)
                {
                    Console.WriteLine("The found valus is: {0}.", sequence[~index - 1]);
                }
                else
                {
                    Console.WriteLine("All the values in the sequence are bigger than {0}.", k);
                }
            }
        }
    }
}
