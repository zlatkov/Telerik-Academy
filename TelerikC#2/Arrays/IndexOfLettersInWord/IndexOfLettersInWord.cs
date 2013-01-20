using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfLettersInWord
{
    class IndexOfLettersInWord
    {
        static void Main(string[] args)
        {
            const int numberOfLetters = 26;
            char[] letters = new char[numberOfLetters];
            for (int i = 0; i < 26; ++i)
            {
                letters[i] = (char)((int)'a' + i);
            }

            string word = Console.ReadLine();
            for (int i = 0; i < word.Length; ++i)
            {
                for (int j = 0; j < numberOfLetters; ++j)
                {
                    if (word[i] == letters[j])
                    {
                        Console.WriteLine(j);
                        break;
                    }
                }
            }
        }
    }
}
