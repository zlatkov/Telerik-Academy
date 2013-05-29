using System;
using System.Linq;

namespace _2.CalculateStatistics
{
    class CalculateStatistics
    {
        static void Main(string[] args)
        {
        }
        public void PrintStatistics(double[] arr)
        {
            Console.WriteLine(FindMaxNumber(arr));
            Console.WriteLine(FindMinNumber(arr));
            Console.WriteLine(FindAverage(arr));
        }

        private double FindAverage(double[] numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            double average = sum / numbers.Length;
            return average;
        }

        private double FindMinNumber(double[] numbers)
        {
            double minNumber = double.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }
            return minNumber;
        }

        private double FindMaxNumber(double[] numbers)
        {
            double maxNumber = double.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }
            return maxNumber;
        }
    }
}
