using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallDown
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] row = new byte[8];

            for (int i = 0; i < 8; ++i)
            {
                row[i] = byte.Parse(Console.ReadLine());
            }

            byte tmp;
            for (int i = 6; i >= 0; --i)
            {
                for (int j = i; j < 7; ++j)
                {
                    tmp = row[j + 1];
                    row[j + 1] |= row[j];
                    row[j] &= tmp;
                }
            }

            for (int i = 0; i < 8; ++i)
            {
                Console.WriteLine(row[i]);
            }
        }
    }
}
