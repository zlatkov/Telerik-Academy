using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<double> t = new Matrix<double>(3, 2);
            if (t)
            {
                Console.WriteLine("t is true before");
            }
            else
            {
                Console.WriteLine("t is false before");
            }

            t[0, 0] = 432.5343;
            if (t)
            {
                Console.WriteLine("t is true after");
            }
            else
            {
                Console.WriteLine("t i false after");
            }

            Matrix<int> a = new Matrix<int>(2, 2);

            //Fibonacci matrix;
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 0;


            Matrix<int> result = a;

            for (int i = 0; i < 10; ++i)
            {
                result = result * a;
                Console.WriteLine(result); //result a[0, 0] is the current fibonacci number
            }

        }
    }
}
