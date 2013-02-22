using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int skip = (n - 2) >> 1;
            int skipMod;

            for (int i = 0; i < (n >> 1); ++i)
            {
                skipMod = skip % 2; 
                for (int j = 0; j < (n >> 1); ++j)
                {
                    if (j < skip)
                    {
                        Console.Write(".");
                    }
                    else if (j >= skip && (j % 2 == skipMod % 2))
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                for (int j = (n >> 1); j < n; ++j)
                {
                    if (j >= n - skip)
                    {
                        Console.Write(".");
                    }
                    else if (j < n - skip && (j % 2 == 1 - skipMod % 2))
                    {
                        Console.Write("\\");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                skip--;
                Console.Write("\n");
            }

            skip = 0;
            for (int i = (n >> 1); i < n; ++i)
            {
                skipMod = 1 - (skip % 2);
                for (int j = 0; j < (n >> 1); ++j)
                {
                    if (j < skip)
                    {
                        Console.Write(".");
                    }
                    else if (j >= skip && (j % 2 == 1 - (skipMod % 2)))
                    {
                        Console.Write("\\");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                for (int j = (n >> 1); j < n; ++j)
                {
                    if (j >= n - skip)
                    {
                        Console.Write(".");
                    }
                    else if (j < n - skip && (j % 2 == skipMod % 2))
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                skip++;
                Console.Write("\n");
            }
        }
    }
}
