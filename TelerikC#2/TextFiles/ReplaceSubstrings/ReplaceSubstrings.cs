using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace ReplaceSubstrings
{
    class ReplaceSubstrings
    {
        static void Main(string[] args)
        {
            string inputFileName = Console.ReadLine();
            string outputFileName = Console.ReadLine();

            try
            {
                StringBuilder result = new StringBuilder();
                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        int begSearch = 0;
                        int currentFoundIndex = line.IndexOf("start", begSearch);
                        while (currentFoundIndex >= 0)
                        {
                            string subString = line.Substring(begSearch, currentFoundIndex - begSearch);
                            result.Append(subString);
                            result.Append("finish");

                            begSearch = currentFoundIndex + 5;
                            currentFoundIndex = line.IndexOf("start", begSearch);
                        }
                        string lastSubstring = line.Substring(begSearch);
                        result.Append(lastSubstring);
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
