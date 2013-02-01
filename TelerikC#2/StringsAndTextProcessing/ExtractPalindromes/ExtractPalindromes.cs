using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExtractPalindromes
{
    class ExtractPalindromes
    {
        static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; ++i)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            MatchCollection words = Regex.Matches(text, @"\w+");
            foreach (Match word in words)
            {
                if (IsPalindrome(word.Value))
                {
                    Console.WriteLine(word.Value);
                }
            }
        }
    }
}
