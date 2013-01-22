using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadOddLines
{
    class ReadOddLines
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();
            int lineNumber = 1;

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {   
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (lineNumber % 2 == 1)
                        {
                            Console.WriteLine(line);
                        }
                        line = reader.ReadLine();
                        lineNumber++;
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
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
