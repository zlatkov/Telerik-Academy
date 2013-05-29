namespace _1.ConsolePrinter
{
    using System;
    using System.Linq;

    class ConsolePrinter
    {
        const int MaxCount = 6;

        static void Main(string[] args)
        {
            BoolPrinter printer = new BoolPrinter();
            printer.PrintBool(true);
        }

        class BoolPrinter
        {
            public void PrintBool(bool value)
            {
                string boolAsString = value.ToString();
                Console.WriteLine(boolAsString);
            }
        }
    }
}