using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.IO;

namespace DeleteOddLines
{
    class DeleteOddLines
    {
        static void Main(string[] args)
        {
            string inputFileName = Console.ReadLine();

            try
            {
                StringBuilder result = new StringBuilder();
                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    string line = reader.ReadLine();
                    int lineNumber = 1;

                    while (line != null)
                    {
                        if (lineNumber % 2 == 0)
                        {
                            result.Append(line);
                            result.Append("\n");
                        }

                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
                using (StreamWriter writer = new StreamWriter(inputFileName))
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
