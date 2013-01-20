using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsoscelesTriangle
{
    class IsoscelesTriangle
    {
        static void Main(string[] args)
        {
            int symbolCode = 169;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < (2 - i); ++j)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < (2 * i + 1); ++j)
                {
                    Console.Write((char)symbolCode);
                }
                Console.Write("\n");
            }
        }
    }
}
