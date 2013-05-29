using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.RefactoredLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valueIsFound = false;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);
                    if (array[i] == expectedValue)
                    {
                        valueIsFound = true;
                        break;
                    }
                }
            }
            if (valueIsFound)
            {
                Console.WriteLine("Value Found");
            }

        }
    }
}
