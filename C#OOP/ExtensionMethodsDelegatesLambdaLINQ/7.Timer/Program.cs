using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Timer
{
    class Program
    {
        public static void PrintText()
        {
            Console.WriteLine("Some text.");
        }
        static void Main(string[] args)
        {
            Timer timer = new Timer(PrintText, 10, 1000);
            timer.Start();
        }
    }
}
