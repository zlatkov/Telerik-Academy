using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Bit64Array
{
    class Tester
    {
        static void Main(string[] args)
        {
            Bit64Array bitArray1 = new Bit64Array();
            bitArray1[0] = 1;
            bitArray1[1] = 1;
            bitArray1[1] = 1;

            foreach (var bit in bitArray1)
            {
                Console.WriteLine(bit);
            }

            Bit64Array bitArray2 = new Bit64Array(3);

            Console.WriteLine("bitArray1 == bitArray2 " + (bitArray1 == bitArray2));

            bitArray2[46] = 1;
            Console.WriteLine("bitArray1 == bitArray2 " + (bitArray1 == bitArray2));

            Console.WriteLine("bitArray1.GetHashCode(): " + bitArray1.GetHashCode());
            Console.WriteLine("bitArray2.GetHashCode(): " + bitArray2.GetHashCode());

        }
    }
}
