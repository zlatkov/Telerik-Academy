using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CountWords
{
    class CountWords
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            MatchCollection collection = Regex.Matches(text, @"\w+");
            foreach (Match match in collection)
            {
                int currentCount;
                wordFrequency.TryGetValue(match.Value, out currentCount);

                currentCount++;
                wordFrequency[match.Value] = currentCount;
            }

            foreach (var pair in wordFrequency)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }
}
