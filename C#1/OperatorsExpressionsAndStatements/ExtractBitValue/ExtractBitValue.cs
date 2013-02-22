using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtractBitValue
{
    class ExtractBitValue
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int bitPosition = Convert.ToInt32(Console.ReadLine());

            int bitValue = ((number & (1 << bitPosition)) != 0) ? 1 : 0;
            Console.WriteLine(bitValue);
        }
    }
}
