using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace CountWordsOccurrencesInFile
{
    class ComparePairs : IComparer<KeyValuePair<string, int>>
    {
        public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
        {
            if (x.Value > y.Value)
            {
                return -1;
            }
            else if (x.Value < y.Value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    class CountWordsOccurrencesInFile
    {
        static List<string> ExtractWordsFromLine(string line)
        {
            List<string> words = new List<string>(); 
            StringBuilder word = new StringBuilder();

            foreach (char symbol in line)
            {
                if (symbol == ' ' && word.ToString() != String.Empty)
                {
                    words.Add(word.ToString());
                    word.Clear();
                }
                else
                {
                    word.Append(symbol);
                }
            }

            if (word.ToString() != String.Empty)
            {
                words.Add(word.ToString());
            }

            return words;
        }
        static List<string> ExtractWordsFromFile(string wordsFileName)
        {
            List<string> words = new List<string>();

            using (StreamReader reader = new StreamReader(wordsFileName))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    List<string> wordsOnLine = ExtractWordsFromLine(line);
                    words.AddRange(wordsOnLine);

                    line = reader.ReadLine();
                }
            }

            return words;
        }

        static void Main(string[] args)
        {
            try
            {
                List<string> wordsToSearch = ExtractWordsFromFile("words.txt");
                List<string> wordsInFile = ExtractWordsFromFile("test.txt");

                List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();

                foreach (string wordToSearch in wordsToSearch)
                {
                    int occurrences = 0;
                    foreach (string wordInFile in wordsInFile)
                    {
                        if (wordToSearch == wordInFile)
                        {
                            occurrences++;
                        }
                    }
                    result.Add(new KeyValuePair<string, int>(wordToSearch, occurrences));
                }

                result.Sort(new ComparePairs());

                using (StreamWriter writer = new StreamWriter("result.txt"))
                {
                    foreach (KeyValuePair<string, int> entry in result)
                    {
                        writer.WriteLine(entry.Key + " " + entry.Value);
                    }
                }
            }
            catch (OutOfMemoryException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
