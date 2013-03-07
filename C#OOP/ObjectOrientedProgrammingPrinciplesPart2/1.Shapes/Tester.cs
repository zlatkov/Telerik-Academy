using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    class Tester
    {
        static void Main(string[] args)
        {
            Shape[] shapes = 
            {
                new Rectangle(2, 4),
                new Triangle(3, 7),
                new Circle(8)
            };

            foreach(var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
