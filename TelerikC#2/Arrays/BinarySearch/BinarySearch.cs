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

            int[] sortedSequence = new int[n];
            for (int i = 0; i < n; ++i)
            {
                sortedSequence[i] = int.Parse(Console.ReadLine());
            }

            int element = int.Parse(Console.ReadLine());

            int left = -1, right = n, middle = -1;
            while (left + 1 < right)
            {
                middle = (left + right) >> 1;
                if (sortedSequence[middle] == element)
                {
                    break;
                }
                else if (sortedSequence[middle] < element)
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }

            if (sortedSequence[middle] == element)
            {
                Console.WriteLine(middle);
            }
            else
            {
                Console.WriteLine("Element not found.");
            } 
        }
    }
}
