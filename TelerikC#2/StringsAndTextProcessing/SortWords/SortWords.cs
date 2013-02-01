using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SortWords
{
    class SortWords
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();
            MatchCollection collection = Regex.Matches(words, @"\w+");

            List<string> sortedWords = new List<string>();
            foreach (Match match in collection)
            {
                sortedWords.Add(match.Value);
            }

            sortedWords.Sort();
            foreach(string word in sortedWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
