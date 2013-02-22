using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcualteSquareRoot
{
    class CalcualteSquareRoot
    {
        static double SquareRoot(string numberString)
        {
            int number = int.Parse(numberString);

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid number");
            }

            double result = Math.Sqrt(number);
            return result;
        }

        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            try
            {
                double result = SquareRoot(number);
                Console.WriteLine(result);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }
    }
}
