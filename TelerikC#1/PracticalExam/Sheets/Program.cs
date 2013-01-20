using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheets
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = int.Parse(Console.ReadLine());
            int mask = (1 << 11) - 1;

            for (int i = 10; i >= 0; --i)
            {
                if ((total & (1 << (10 - i))) > 0)
                {
                    mask ^= 1 << i;
                }
            }
            for (int i = 10; i >= 0; --i)
            {
                if ((mask & (1 << i)) > 0)
                {
                    Console.WriteLine("A" + i);
                }
            }
        }
    }
}
