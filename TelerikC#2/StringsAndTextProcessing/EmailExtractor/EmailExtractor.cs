using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EmailExtractor
{
    class EmailExtractor
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            MatchCollection emails = Regex.Matches(text, @"\w+@\w+\.\w+");

            foreach (Match email in emails)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}
