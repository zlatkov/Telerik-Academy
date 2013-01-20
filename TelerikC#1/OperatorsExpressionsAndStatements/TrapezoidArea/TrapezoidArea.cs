using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrapezoidArea
{
    class TrapezoidArea
    {
        static void Main(string[] args)
        {
            double sideA = Convert.ToDouble(Console.ReadLine());
            double sideB = Convert.ToDouble(Console.ReadLine());
            double height = Convert.ToDouble(Console.ReadLine());

            double trapezoidArea = ((sideA + sideB) / 2d) * height;
            Console.WriteLine("Area: {0}.", trapezoidArea);
        }
    }
}
