using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetThirdBitValue
{
    class GetThirdBitValue
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());

            bool thirdBitIsOne = (number & (1 << 3)) != 0;
            Console.WriteLine(thirdBitIsOne.ToString());
        }
    }
}
