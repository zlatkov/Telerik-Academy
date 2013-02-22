using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModifyBitValue
{
    class ModifyBitValue
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int bitPosition = Convert.ToInt32(Console.ReadLine());
            int bitValue = Convert.ToInt32(Console.ReadLine());

            number = (((number >> bitPosition) & 1) > bitValue) ? (number & (~(1 << bitPosition))) : (number | (1 << bitPosition));
            
            Console.WriteLine(number);
        }
    }
}
