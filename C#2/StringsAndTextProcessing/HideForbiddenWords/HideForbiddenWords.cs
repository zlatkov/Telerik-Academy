using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HideForbiddenWords
{
    class HideForbiddenWords
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            const string forbiddenWords = "PHP, CLR, Microsoft";

            string regexList = forbiddenWords.Replace(", ", "|");
            string censoredText = Regex.Replace(text, regexList, word => new String('*', word.Length), RegexOptions.IgnoreCase);

            Console.WriteLine(censoredText);
        }
    }
}
