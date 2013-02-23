using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.CapitalizeWordFirstLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello! This is some random text to test the extension method.";
            Console.WriteLine(text.ToTitleCase());
        }
    }
}
