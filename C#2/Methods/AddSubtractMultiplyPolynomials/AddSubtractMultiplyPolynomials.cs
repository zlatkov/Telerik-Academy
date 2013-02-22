using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSubtractMultiplyPolynomials
{
    class Polynomial
    {
        private List<double> coefficients;

        public Polynomial()
        {
            coefficients = new List<double>();
        }

        public int PolynomialDegree
        {
            get
            {
                return coefficients.Count - 1;
            }
        }

        public double this[int index]
        {
            get
            {
                if (index >= 0 && index < coefficients.Count)
                {
                    return coefficients[index];
                }
                else
                {
                    return 0.0;
                }
            }

            set
            {
                if (index >= 0 && index < coefficients.Count)
                {
                    coefficients[index] = value;
                }
            }
        }

        private void AddCoefficient(double coef)
        {
            coefficients.Add(coef);
        }

        public void ReadPolynomial()
        {
            Console.Write("Enter the polynomial degree: ");
            int polynomialDegree = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the polynomial coefficients:");
            for (int i = 0; i <= polynomialDegree; ++i)
            {
                coefficients.Add(double.Parse(Console.ReadLine()));
            }
        }

        private void Normalize()
        {
            if (PolynomialDegree >= 0)
            {
                while (coefficients[PolynomialDegree] == 0.0)
                {
                    coefficients.RemoveAt(PolynomialDegree);

                }
            }
        }

        public static Polynomial operator +(Polynomial x, Polynomial y)
        {
            int biggerDegree = Math.Max(x.PolynomialDegree, y.PolynomialDegree);
            Polynomial result = new Polynomial();

            double tmp = 0.0;
            for (int i = 0; i <= biggerDegree; ++i)
            {
                tmp = 0.0;
                if (i <= x.PolynomialDegree)
                {
                    tmp += x[i];
                }
                if (i <= y.PolynomialDegree)
                {
                    tmp += y[i];
                }

                result.AddCoefficient(tmp);
            }

            result.Normalize();
            return result;
        }

        public static Polynomial operator -(Polynomial x)
        {
            Polynomial result = new Polynomial();
            for (int i = 0; i <= x.PolynomialDegree; ++i)
            {
                result.AddCoefficient(-x[i]);
            }
            return result;
        }

        public static Polynomial operator -(Polynomial x, Polynomial y)
        {
            Polynomial result = x + (-y);
            return result;
        }

        public static Polynomial operator *(Polynomial x, Polynomial y)
        {
            Polynomial result = new Polynomial();
            for (int i = 0; i <= x.PolynomialDegree; ++i)
            {
                for (int j = 0; j <= y.PolynomialDegree; ++j)
                {
                    if (result.PolynomialDegree < i + j)
                    {
                        result.AddCoefficient(0.0);
                    }
                    result[i + j] += x[i] * y[j];
                }
            }
            result.Normalize();
            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            for (int i = PolynomialDegree; i >= 0; --i)
            {
                if (i != PolynomialDegree)
                {
                    result.Append(" ");
                }
                result.Append(coefficients[i].ToString());
            }
            return result.ToString();
        }
    }
    class AddSubtractMultiplyPolynomial
    {
        static void Main(string[] args)
        {
            Polynomial a = new Polynomial();
            Polynomial b = new Polynomial();

            a.ReadPolynomial();
            b.ReadPolynomial();

            Polynomial r = a + b;
            Console.WriteLine("Addition: " + r.ToString());
            r = a - b;
            Console.WriteLine("Subtraction: " + r.ToString());
            r = a * b;
            Console.WriteLine("Multiplication: " + r.ToString());

        }
    }
}
