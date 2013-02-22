using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadRangeOfNumbers
{
    class ReadRangeOfNumbers
    {
        static int ReadNumber(int leftRange, int rightRange)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < leftRange || number > rightRange)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return number;
            }
            catch (OverflowException oe)
            {
                throw new OverflowException("The number is too big.");
            }
            catch (FormatException fe)
            {
                throw new FormatException("The entered string was not a number.", fe);
            }
        }

        static void Main(string[] args)
        {
            int currentNumber = 0;
            int leftRange = 2;
            int numbersEntered = 0;

            while (numbersEntered < 10)
            {
                try
                {
                    currentNumber = ReadNumber(leftRange, 99);
                    leftRange = currentNumber + 1;
                    numbersEntered++;
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                catch (ArgumentOutOfRangeException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
        }
    }
}
