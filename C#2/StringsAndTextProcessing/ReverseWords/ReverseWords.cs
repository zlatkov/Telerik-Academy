using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ReverseWords
{
    class ReverseWords
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            const string regexSplitSymbols = @"\s+|,\s*|\.\s*|!\s*|\?\s*|$";

            string[] words = Regex.Split(text, regexSplitSymbols);

            Stack<string> wordsReversed = new Stack<string>();
            foreach (var word in words)
            {
                if (!String.IsNullOrEmpty(word))
                {
                    wordsReversed.Push(word);
                }
            }

            MatchCollection collection = Regex.Matches(text, regexSplitSymbols);
            foreach (var match in collection)
            {
                if (wordsReversed.Count > 0)
                {
                    Console.Write(wordsReversed.Pop());
                }
                Console.Write(match);
            }
            Console.Write("\n");
        }
    }
}
