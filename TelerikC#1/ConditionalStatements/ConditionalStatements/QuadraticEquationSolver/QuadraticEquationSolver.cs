using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationSolver
{
    class QuadraticEquationSolver
    {
        static void Main(string[] args)
        {
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
            double c = Convert.ToDouble(Console.ReadLine());

            double discriminant = b * b - 4d * a * c;
            if (discriminant < 0d)
            {
                Console.WriteLine("The equation doesn't have real roots.");
            }
            else if (discriminant == 0d)
            {
                double x = -b / (2d * a);

                Console.WriteLine("The equation has single root: " + x);
            }
            else
            {
                double x1 = (-b - Math.Sqrt(discriminant)) / (2d * a);
                double x2 = (-b + Math.Sqrt(discriminant)) / (2d * a);

                Console.WriteLine("The equation has roots: {0} and {1}.", x1, x2);
            }
        }
    }
}
