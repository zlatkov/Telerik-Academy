using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullableTypes
{
    class NullableTypes
    {
        static void Main(string[] args)
        {
            int? nullableInt = null;
            double? nullableDouble = null;

            Console.WriteLine(nullableInt);
            Console.WriteLine(nullableDouble);

            nullableInt = 12345;
            Console.WriteLine(nullableInt);

            nullableDouble = 12345.678;
            Console.WriteLine(nullableDouble);
        }
    }
}
