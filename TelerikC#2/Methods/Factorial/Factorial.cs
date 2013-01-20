using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class BigInteger
    {
        static readonly int Base = 10000000; //Because 100 * Base < Int.MaxValue
        List<int> digits = new List<int>();

        public BigInteger()
        { 
        }

        public BigInteger(int x)
        {
            digits.Add(x);
        }

        public int NumberOfDigits
        {
            get
            {
                return digits.Count;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < NumberOfDigits)
                {
                    return digits[index];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (index >= 0 && index < NumberOfDigits)
                {
                    digits[index] = value;
                }
            }
        }

        public void AddDigit(int x)
        {
            digits.Add(x);
        }

        public static BigInteger operator *(int x, BigInteger y)
        {
            BigInteger result = new BigInteger();
            int carry = 0;

            for (int i = 0; i < y.NumberOfDigits; ++i)
            {
                carry += x * y[i];

                result.AddDigit(carry % Base);
                carry /= Base;
            }

            while (carry > 0)
            {
                result.AddDigit(carry % Base);
                carry /= Base;
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            if (NumberOfDigits > 0)
            {
                result.Append(digits[NumberOfDigits - 1].ToString());
                for (int i = NumberOfDigits - 2; i >= 0; --i)
                {
                    result.Append(String.Format("{0:D7}", digits[i]));
                }
            }
            return result.ToString();
        }
    }
    class Factorial
    {
        static BigInteger CalculateFactorial(int n)
        {
            BigInteger result = new BigInteger(1);
            for (int i = 2; i <= n; ++i)
            {
                result = i * result;
            }

            return result;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger result = CalculateFactorial(n);
            Console.WriteLine(result.ToString());
        }
    }
}
