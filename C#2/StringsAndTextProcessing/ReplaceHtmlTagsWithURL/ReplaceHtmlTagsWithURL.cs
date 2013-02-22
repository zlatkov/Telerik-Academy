using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ReplaceHtmlTagsWithURL
{
    class ReplaceHtmlTagsWithURL
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result = Regex.Replace(text, @"<\s*a\s*href\s*=\s*""(.*?)""\s*>\s*\b(.*?)\b\s*<\s*/a\s*>", "[URL=$1]$2[/URL]");
            Console.WriteLine(result);
        }
    }
}
