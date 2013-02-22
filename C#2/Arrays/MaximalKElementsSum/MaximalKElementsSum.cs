using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalKElementsSum
{
    class MaximalKElementsSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] sequence = new int[n];
            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int currentMaximalIndex = -1;
            bool[] used = new bool[n];


            for (int j = 0; j < k; ++j)
            {
                currentMaximalIndex = -1;
                for (int i = 0; i < n; ++i)
                {
                    if (used[i] == false)
                    {
                        currentMaximalIndex = i;
                        break;
                    }
                }
                if (currentMaximalIndex != -1)
                {
                    for (int i = 0; i < n; ++i)
                    {
                        if (used[i] == false && sequence[i] > sequence[currentMaximalIndex])
                        {
                            currentMaximalIndex = i;
                        }
                    }

                    used[currentMaximalIndex] = true;
                    Console.WriteLine(sequence[currentMaximalIndex]);
                }
            }
        }
    }
}
