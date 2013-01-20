using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddNumbersAsArrays
{
    class AddNumbersAsArrays
    {
        static int[] ReadNumberAsArray()
        {
            Console.Write("Enter the number of digits: ");
            int numberOfDigits = int.Parse(Console.ReadLine());
            int[] digits = new int[numberOfDigits];

            Console.WriteLine("Enter the digits of the number:");
            for (int i = 0; i < numberOfDigits; ++i)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            return digits;
        }

        static int[] AddNumbers(int[] firstNumber, int[] secondNumber)
        {
            List<int> result = new List<int>();

            int firstNumberLength = firstNumber.GetLength(0);
            int secondNumberLength = secondNumber.GetLength(0);
            int biggerNumberLength = Math.Max(firstNumberLength, secondNumberLength);
            int carry = 0;

            for (int i = 0; i < biggerNumberLength; ++i)
            {
                if (i < firstNumberLength)
                {
                    carry += firstNumber[i];
                }
                if (i < secondNumberLength)
                {
                    carry += secondNumber[i];
                }

                result.Add(carry % 10);
                carry /= 10;
            }

            if (carry > 0)
            {
                result.Add(carry);
            }

            return result.ToArray();
        }

        static void Main(string[] args)
        {
            int[] firstNumber = ReadNumberAsArray();
            int[] secondNumber = ReadNumberAsArray();

            int[] sum = AddNumbers(firstNumber, secondNumber);

            int sumLength = sum.GetLength(0);
            for (int i = sumLength - 1; i >= 0; --i)
            {
                Console.Write(sum[i]);
            }
            Console.Write("\n");

        }
    }
}
