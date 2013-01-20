using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetBitValue
{
    class GetBitValue
    {
        static void Main(string[] args)
        {
            int position = Convert.ToInt32(Console.ReadLine());
            int number = Convert.ToInt32(Console.ReadLine());

            bool bitValusIsOne = (number & (1 << position)) != 0;
            Console.WriteLine(bitValusIsOne);

        }
    }
}
