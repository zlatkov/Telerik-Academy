using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllocateAndInitializeArray
{
    class AllocateAndInitializeArray
    {
        static void Main(string[] args)
        {
            int[] elements = new int[20];
            for (int i = 0; i < 20; ++i)
            {
                elements[i] = i * 5;
                Console.WriteLine(elements[i]);
            }
        }
    }
}
