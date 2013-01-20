using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePerimeterArea
{
    class CirclePerimeterArea
    {
        static void Main(string[] args)
        {
            double radius = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Circle perimeter: " + 2D * Math.PI * radius);
            Console.WriteLine("Circle area: " + Math.PI * radius * radius);
        }
    }
}
