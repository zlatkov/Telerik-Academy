using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowBinaryRepresentation
{
    class ShowBinaryRepresentation
    {
        static void Main(string[] args)
        {
            short x = short.Parse(Console.ReadLine());

            for (int i = 15; i >= 0; --i)
            {

                Console.Write((x >> i) & 1);
            }
            Console.Write("\n");
        }
    }
}
