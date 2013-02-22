using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsideCircleOutsideRectangle
{
    class InsideCircleOutsideRectangle
    {
        static void Main(string[] args)
        {
            double pointX = Convert.ToDouble(Console.ReadLine());
            double pointY = Convert.ToDouble(Console.ReadLine());

            bool pointIsInCircle = Math.Pow(pointX - 1d, 2d) + Math.Pow(pointY - 1d, 2d) <= 9d;
            bool pointIsInsideRectangle = (pointX >= -1 && pointX <= 5 && pointY <= 1 && pointY >= -1);

            if (pointIsInCircle && !pointIsInsideRectangle)
            {
                Console.WriteLine("The point is inside the circle and outside the rectangle.");
            }
            else
            {
                Console.WriteLine("The point is not (inside the cirle and outside the rectangle).");
            }
        }
    }
}
