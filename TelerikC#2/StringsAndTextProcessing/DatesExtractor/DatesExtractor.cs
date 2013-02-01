using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DatesExtractor
{
    class DatesExtractor
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            MatchCollection dates = Regex.Matches(text, @"\b\d{2}.\d{2}.\d{4}\b");
            foreach (Match date in dates)
            {
                Console.WriteLine(date.Value);
            }
        }
    }
}
