using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareIntArrays
{
    class CompareIntArrays
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of elements of the first array: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the elements of the first array:");
            int[] firstArray = new int[n];
            for (int i = 0; i < n; ++i)
            {
                firstArray[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter the number of elements of the second array: ");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the elements of the second array:");
            int[] secondArray = new int[m];
            for (int i = 0; i < m; ++i)
            {
                secondArray[i] = int.Parse(Console.ReadLine());
            }

            if (n != m)
            {
                Console.WriteLine("The two arrays are different.");
            }
            else
            {
                bool equal = true;
                for (int i = 0; i < n; ++i)
                {
                    if (firstArray[i] != secondArray[i])
                    {
                        equal = false;
                        break;
                    }
                }

                if (equal)
                {
                    Console.WriteLine("The two arrays are equal.");
                }
                else
                {
                    Console.WriteLine("The two arrays are different.");
                }
            }
        }
    }
}
