using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("The sides should be positive numbers.");
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("The inequality of the triangle is violated.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        static string ConvertDigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("The value should be a single digit [0...9].");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException();
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("The method must take atleast one parameter.");
            }

            int maximalElementIndex = 0;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[maximalElementIndex])
                {
                    maximalElementIndex = i;
                }
            }

            return elements[maximalElementIndex];
        }

        public static void PrintNumber(double value, int digits)
        {
            string format = "{0:F" + digits + "}";
            Console.WriteLine(format, value);
        }

        public static void PrintPercent(double value, int digits)
        {
            string format = "{0:P" + digits + "}";
            Console.WriteLine(format, value);
        }

        public static void PrintAligned(object value, int totalWidth)
        {
            string format = "{0," + totalWidth + "}";
            Console.WriteLine(format, value);
        }

        static bool IsHorizontalLine(double y1, double y2)
        {
            return y1 == y2;
        }

        static bool IsVerticalLine(double x1, double x2)
        {
            return x1 == x2;
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumber(1.3, 2);
            PrintPercent(0.75, 0);
            PrintAligned(2.30, 8);

            bool horizontal = IsHorizontalLine(3, 3);
            bool vertical = IsVerticalLine(-1, 2.5);
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { 
                FirstName = "Peter", 
                LastName = "Ivanov", 
                DateOfBirth = new DateTime(1992, 03, 17) 
            };

            
            Student stella = new Student() 
            { 
                FirstName = "Stella", 
                LastName = "Markova",
                DateOfBirth = new DateTime(1993, 03, 11)
            };

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
