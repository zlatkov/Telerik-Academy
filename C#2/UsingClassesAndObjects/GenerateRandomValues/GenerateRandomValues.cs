using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenerateRandomValues
{
    class GenerateRandomValues
    {
        static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine(randomGenerator.Next(100, 201));
            }
        }
    }
}
