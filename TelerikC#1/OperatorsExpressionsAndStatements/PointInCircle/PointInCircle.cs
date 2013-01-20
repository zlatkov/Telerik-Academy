using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointInCircle
{
    class PointInCircle
    {
        static void Main(string[] args)
        {
            double pointX = Convert.ToDouble(Console.ReadLine());
            double pointY = Convert.ToDouble(Console.ReadLine());

            bool pointInCircle = ((pointX * pointX) + (pointY * pointY) <= 25d);

            if (pointInCircle)
            {
                Console.WriteLine("The point is inside or on the cirle.");
            }
            else
            {
                Console.WriteLine("The point is outside the circle.");
            }
        }
    }
}
