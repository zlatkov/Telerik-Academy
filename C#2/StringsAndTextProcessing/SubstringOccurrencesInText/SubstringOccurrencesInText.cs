using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SubstringOccurrencesInText
{
    class SubstringOccurrencesInText
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string searchString = Console.ReadLine();

            int count = Regex.Matches(text.ToLower(), searchString.ToLower()).Count;
            Console.WriteLine(count);
        }
    }
}
