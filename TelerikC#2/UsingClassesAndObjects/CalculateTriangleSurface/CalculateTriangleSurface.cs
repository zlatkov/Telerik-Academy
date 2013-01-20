using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTriangleSurface
{
    class CalculateTriangleSurface
    {
        static double SurfaceBySideAndAltitude(double side, double altitude)
        {
            double surface = (side * altitude) / 2.0;
            return surface;
        }

        static double SurfaceByThreeSides(double a, double b, double c)
        {
            if ((a > b + c) && (b > a + c) && (c > a + b)) //Invalid triangle.
            {
                return -1;
            }
            else
            {
                double halfPerimeter = (a + b + c) / 2.0;
                double surface = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
                return surface;
            }
        }

        static double DegreeToRadians(double alpha)
        {
            return (Math.PI / 180.0d) * alpha;
        }

        static double SurfaceByTwoSidesAndAngle(double a, double b, double alpha)
        {
            double radians = DegreeToRadians(alpha);
            double surface = a * b * Math.Sin(radians) / 2.0;
            return surface;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(SurfaceBySideAndAltitude(5.0, 3.0));
            Console.WriteLine(SurfaceByThreeSides(2.0, 3.0, 4.0));
            Console.WriteLine(SurfaceByTwoSidesAndAngle(2.0, 3.0, 90));
        }
    }
}
