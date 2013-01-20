using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateExpression
{
    class CalculateExpression
    {
        static int GetPriority(char arithmeticOperator)
        {
            if (arithmeticOperator == '+' || arithmeticOperator == '-')
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        static bool IsOperator(char ch)
        {
            return (ch == '+' || ch == '-' || ch == '*' || ch == '/');
        }

        static KeyValuePair<int, double> GetNumber(int startIndex, string expression)
        {
            string number = "";
            int endIndex = startIndex + 1;

            while (endIndex < expression.Length && ((expression[endIndex] >= '0' && expression[endIndex] <= '9') || expression[endIndex] == '.'))
            {
                endIndex++;   
            }

            endIndex--;
            KeyValuePair<int, double> result = new KeyValuePair<int, double>(endIndex, double.Parse(expression.Substring(startIndex, endIndex - startIndex + 1)));

            return result;
        }

        static KeyValuePair<int, List<string>> GetFunctionParameters(int startIndex, string expression)
        {
            List<string> parameters = new List<string>();
            string currentParameter = "";

            int balancedBrackets = 1;
            int endIndex = startIndex + 1;
            while (balancedBrackets != 0 && endIndex < expression.Length)
            {
                if (expression[endIndex] == ',' && balancedBrackets == 1)
                {
                    parameters.Add(currentParameter);
                    currentParameter = "";
                }
                else
                {
                    if (expression[endIndex] == '(')
                    {
                        balancedBrackets++;
                    }
                    else if (expression[endIndex] == ')')
                    {
                        balancedBrackets--;
                    }

                    if (balancedBrackets != 0)
                    {
                        currentParameter += expression[endIndex];
                    }
                }
                endIndex++;
            }
            endIndex--;

            if (currentParameter != String.Empty)
            {
                parameters.Add(currentParameter);
            }

            KeyValuePair<int, List<string>> result = new KeyValuePair<int, List<string>>(endIndex, parameters);
            return result;
        }

        static KeyValuePair<int, double> CalculateLogarithm(int startIndex, string expression)
        {
            KeyValuePair<int, List<string>> functionParameter = GetFunctionParameters(startIndex + 2, expression);

            double parameterValue = Calculate(functionParameter.Value[0]);
            KeyValuePair<int, double> result = new KeyValuePair<int,double>(functionParameter.Key, Math.Log(parameterValue));
            return result;
        }

        static KeyValuePair<int, double> CalculateSqrt(int startIndex, string expression)
        {
            KeyValuePair<int, List<string>> functionParameter = GetFunctionParameters(startIndex + 4, expression);

            double parameterValue = Calculate(functionParameter.Value[0]);
            KeyValuePair<int, double> result = new KeyValuePair<int, double>(functionParameter.Key, Math.Sqrt(parameterValue));
            return result;
        }

        static KeyValuePair<int, double> CalculatePow(int startIndex, string expression)
        {
            KeyValuePair<int, List<string>> functionParameters = GetFunctionParameters(startIndex + 3, expression);

            double parameter1Value = Calculate(functionParameters.Value[0]);
            double parameter2Value = Calculate(functionParameters.Value[1]);
            KeyValuePair<int, double> result = new KeyValuePair<int, double>(functionParameters.Key, Math.Pow(parameter1Value, parameter2Value));
            return result;
        }

        static List<KeyValuePair<int, double>> ReversePolishNotation(string expression)
        {
            expression = "(" + expression + ")";
            List<KeyValuePair<int, double>> values = new List<KeyValuePair<int, double>>();
            Stack<char> stack = new Stack<char>();

            int index = 0;
            while (index < expression.Length)
            {
                if (expression[index] == '(')
                {
                    stack.Push('(');
                }
                else if (expression[index] == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        values.Add(new KeyValuePair<int, double>(1, (double)stack.Peek()));
                        stack.Pop();
                    }
                    stack.Pop();
                }
                else if (IsOperator(expression[index]))
                {
                    while (stack.Count > 0 && IsOperator(stack.Peek()) && GetPriority(expression[index]) <= GetPriority(stack.Peek()))
                    {
                        values.Add(new KeyValuePair<int, double>(1, (double)stack.Pop()));
                    }
                    stack.Push(expression[index]);
                }
                else if (expression[index] >= '0' && expression[index] <= '9')
                {
                    KeyValuePair<int, double> number = GetNumber(index, expression);
                    values.Add(new KeyValuePair<int, double>(0, number.Value));
                    index = number.Key;
                }
                else if (expression[index] == 'l')
                {
                    KeyValuePair<int, double> logarithmResult = CalculateLogarithm(index, expression);
                    values.Add(new KeyValuePair<int, double>(0, logarithmResult.Value));
                    index = logarithmResult.Key;
                }
                else if (expression[index] == 's')
                {
                    KeyValuePair<int, double> sqrtResult = CalculateSqrt(index, expression);
                    values.Add(new KeyValuePair<int, double>(0, sqrtResult.Value));
                    index = sqrtResult.Key;
                }
                else if (expression[index] == 'p')
                {
                    KeyValuePair<int, double> powResult = CalculatePow(index, expression);
                    values.Add(new KeyValuePair<int, double>(0, powResult.Value));
                    index = powResult.Key;
                }
                index++;
            }

            return values;
        }

        static double Calculate(string expression)
        {
            List<KeyValuePair<int, double>> values = ReversePolishNotation(expression);
            Stack<double> dynamicResult = new Stack<double>();

            double result = 0.0d;

            int index = 0;
            while (index < values.Count)
            {
                if (values[index].Key == 1)
                {
                    double secondValue = dynamicResult.Pop();
                    double firstValue = dynamicResult.Pop();

                    char arithmeticOperator = (char)values[index].Value;
                    switch (arithmeticOperator)
                    {
                        case '+': dynamicResult.Push(firstValue + secondValue); break;
                        case '-': dynamicResult.Push(firstValue - secondValue); break;
                        case '*': dynamicResult.Push(firstValue * secondValue); break;
                        case '/': dynamicResult.Push(firstValue / secondValue); break;
                    }
                }
                else
                {
                    dynamicResult.Push(values[index].Value);
                }
                index++;
            }
            
            if (dynamicResult.Count > 0)
            {
                result = dynamicResult.Pop();
            }

            return result;
        }

        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            expression = expression.Replace(" ", String.Empty);

            double result = Calculate(expression);
            Console.WriteLine(result);
        }
    }
}
