using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace RemoveWordsListedInFile
{
    class RemoveWordsListedInFile
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
            string inputFileName = Console.ReadLine();
            string wordsFileName = Console.ReadLine();

            try
            {
                List<string> forbiddenWords = ExtractWordsFromFile(wordsFileName);
                List<string> inputFileWords = new List<string>();

                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        inputFileWords.AddRange(ExtractWordsFromLine(line));
                        inputFileWords.Add("\n");
                        line = reader.ReadLine();
                    }
                }

                using (StreamWriter writer = new StreamWriter(inputFileName))
                {
                    foreach (string word in inputFileWords)
                    {
                        if (!forbiddenWords.Contains(word))
                        {
                            writer.Write(word);
                            if (word != "\n")
                            {
                                writer.Write(" ");
                            }
                        }
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
