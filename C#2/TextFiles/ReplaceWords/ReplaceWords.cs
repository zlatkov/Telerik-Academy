using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace ReplaceWords
{
    class ReplaceWords
    {
        static void Main(string[] args)
        {
            string inputFileName = Console.ReadLine();
            string outputFileName = Console.ReadLine();

            try
            {
                StringBuilder result = new StringBuilder();
                StringBuilder word = new StringBuilder();
                bool endOfWord = false;
                bool lastWord = false;
                char symbol;

                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        for (int i = 0; i < line.Length; ++i)
                        {
                            symbol = line[i];

                            if (i == line.Length - 1)
                            {
                                lastWord = true;
                            }
                            else
                            {
                                lastWord = false;
                            }

                            if ((symbol >= '0' && symbol <= '9') || (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z'))
                            {
                                endOfWord = false;
                                word.Append(symbol);
                            }
                            else
                            {
                                endOfWord = true;
                            }

                            if (endOfWord || lastWord)
                            {
                                string tmpWord = word.ToString();
                                if (tmpWord == "start")
                                {
                                    tmpWord = "finish";
                                }
                                result.Append(tmpWord);

                                if (!lastWord)
                                {
                                    result.Append(symbol);
                                }
                                word.Clear();
                            }
                        }
                        
                        result.Append("\n");
                        line = reader.ReadLine();
                    }
                }
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.Write(result.ToString());
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
