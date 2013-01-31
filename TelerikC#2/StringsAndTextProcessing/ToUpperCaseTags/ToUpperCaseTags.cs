using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ToUpperCaseTags
{
    class ToUpperCaseTags
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result = Regex.Replace(text, "<upcase>(.*?)</upcase>", match => match.Groups[1].Value.ToUpper());

            Console.WriteLine(result);
        }
    }
}
