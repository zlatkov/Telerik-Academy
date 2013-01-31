using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExtractSentenceContainingGivenWord
{
    class ExtractSentenceContainingGivenWord
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            const string word = "in";

            MatchCollection m = Regex.Matches(text, @"\s*([^\.]*\b" + word + @"\b.*?\.)");

            foreach (Match match in m)
            {
                Console.WriteLine(match.Groups[1].Value);
            }
        }
    }
}
