using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionCorrectBrackets
{
    class ExpressionCorrectBrackets
    {
        static bool ValidateExpression(string expression)
        {
            int openBrackets = 0;
            for (int i = 0; i < expression.Length; ++i)
            {
                if (expression[i] == '(')
                {
                    openBrackets++;
                }
                else if (expression[i] == ')')
                {
                    openBrackets--;
                }
                if (openBrackets < 0)
                {
                    return false;
                }
            }
            return openBrackets == 0;
        }

        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            bool correct = ValidateExpression(expression);
            Console.WriteLine(correct);
        }
    }
}
