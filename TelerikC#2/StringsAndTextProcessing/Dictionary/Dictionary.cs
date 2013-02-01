using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Dictionary
{
    class Dictionary
    {
        static void Main(string[] args)
        {
            string[] dictionary = new string[]
            {
                ".NET - platform for applications from Microsoft",
                "CLR - managed execution environment for .NET", 
                "namespace - hierarchical organization of classes"
            };

            string word = Console.ReadLine();
            foreach (string item in dictionary)
            {
                Match match = Regex.Match(item, "(.*?) - (.*)");

                if (match.Groups[1].Value == word)
                {
                    Console.WriteLine(match.Groups[2].Value);
                }
            }
        }
    }
}
