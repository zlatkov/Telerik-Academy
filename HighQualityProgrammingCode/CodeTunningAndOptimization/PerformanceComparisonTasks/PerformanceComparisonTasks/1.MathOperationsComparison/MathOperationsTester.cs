using System;
using System.Linq;

namespace _1.MathOperationsComparison
{
    class MathOperationsTester
    {
        static void Main(string[] args)
        {
            // Testing addition.
            AdditionTester.Add(0, 10, 1000000);
            AdditionTester.Add(0L, 10L, 1000000L);
            AdditionTester.Add(0F, 10F, 1000000F);
            AdditionTester.Add(0D, 10D, 1000000D);
            AdditionTester.Add(0M, 10M, 1000000M);

            // Testing subtraction.
            SubtractionTester.Subtract(0, 10, 1000000);
            SubtractionTester.Subtract(0L, 10L, 1000000L);
            SubtractionTester.Subtract(0F, 10F, 1000000F);
            SubtractionTester.Subtract(0D, 10D, 1000000D);
            SubtractionTester.Subtract(0M, 10M, 1000000M);

            // Testing increment.
            IncrementTester.Increment(0, 1000000);
            IncrementTester.Increment(0L, 1000000L);
            IncrementTester.Increment(0F, 1000000F);
            IncrementTester.Increment(0D, 1000000D);
            IncrementTester.Increment(0M, 1000000M);

            // Testing multiplication.
            MultiplicationTester.Multiply(0, 10, 1000000);
            MultiplicationTester.Multiply(0L, 10L, 1000000L);
            MultiplicationTester.Multiply(0F, 10F, 1000000F);
            MultiplicationTester.Multiply(0D, 10D, 1000000D);
            MultiplicationTester.Multiply(0M, 10M, 1000000M);

            // Testing division.
            DivisionTester.Divide(0, 10, 1000000);
            DivisionTester.Divide(0L, 10L, 1000000L);
            DivisionTester.Divide(0F, 10F, 1000000F);
            DivisionTester.Divide(0D, 10D, 1000000D);
            DivisionTester.Divide(0M, 10M, 1000000M);
        }
    }
}
