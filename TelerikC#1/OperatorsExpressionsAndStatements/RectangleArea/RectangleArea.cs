using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RectangleArea
{
    class RectangleArea
    {
        static void Main(string[] args)
        {
            int width = Convert.ToInt32(Console.ReadLine());
            int height = Convert.ToInt32(Console.ReadLine());

            int rectangleArea = width * height;
            Console.WriteLine(rectangleArea);
        }
    }
}
