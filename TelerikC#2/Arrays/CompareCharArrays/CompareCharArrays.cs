using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of elements of the first char array: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the elements of the first array:");
            char[] firstArray = new char[n];
            for (int i = 0; i < n; ++i)
            {
                firstArray[i] = char.Parse(Console.ReadLine());
            }

            Console.Write("Enter the number of elements of the second char array: ");
            int m = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the elements of the second array:");
            char[] secondArray = new char[m];
            for (int i = 0; i < m; ++i)
            {
                secondArray[i] = char.Parse(Console.ReadLine());
            }

            bool equal = true;
            int minimalLength = Math.Min(n, m);
            for (int i = 0; i < minimalLength; ++i)
            {
                if (firstArray[i].CompareTo(secondArray[i]) != 0)
                {
                    equal = false;
                    if (firstArray[i] < secondArray[i])
                    {
                        Console.WriteLine("The first char array is lexicographically before the second one.");
                    }
                    else
                    {
                        Console.WriteLine("The firt char array is lexicographically after the second one.");
                    }
                    break;
                }
            }
            if (equal)
            {
                if (n != m)
                {
                    if (n < m)
                    {
                        Console.WriteLine("The first char array is lexicographically before the second one.");
                    }
                    else
                    {
                        Console.WriteLine("The firt char array is lexicographically after the second one.");
                    }
                }
                else
                {
                    Console.WriteLine("The two char arrays are equal.");
                }
            }
        }
    }
}
