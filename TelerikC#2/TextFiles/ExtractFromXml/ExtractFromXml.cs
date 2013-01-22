using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExtractFromXml
{
    class ExtractFromXml
    {
        static void Main(string[] args)
        {
            string inputFileName = Console.ReadLine();

            try
            {
                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    string content = reader.ReadToEnd();
                    StringBuilder result = new StringBuilder();
                    StringBuilder word = new StringBuilder();
                    bool isInTag = false;

                    foreach (char symbol in content)
                    {
                        if (symbol == '<')
                        {
                            isInTag = true;
                            if (word.ToString() != String.Empty)
                            {
                                result.Append(word);
                                result.Append("\n");
                            }
                            word.Clear();
                            
                        }
                        else if (symbol == '>')
                        {
                            isInTag = false;
                        }
                        else if (!isInTag)
                        {
                            if (symbol != '\n' && symbol != ' ')
                            {
                                word.Append(symbol);
                            }
                        }
                    }
                    Console.WriteLine(result.ToString());
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
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
