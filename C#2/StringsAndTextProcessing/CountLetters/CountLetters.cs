using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountLetters
{
    class CountLetters
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> letterFrequency = new Dictionary<char, int>();
            foreach (char symbol in text)
            {
                int symbolCount;
                letterFrequency.TryGetValue(symbol, out symbolCount);

                letterFrequency[symbol] = symbolCount + 1;
            }

            foreach (var pair in letterFrequency)
            {
                Console.WriteLine("{0} {1}", pair.Key, pair.Value);
            }
        }
    }
}
