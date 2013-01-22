using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace SortNames
{
    class SortNames
    {
        static void Main(string[] args)
        {
            string inputFileName = Console.ReadLine();
            string outputFileName = Console.ReadLine();

            try
            {
                List<string> names = new List<string>();
                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        names.Add(line);
                        line = reader.ReadLine();
                    }
                }

                names.Sort();
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    foreach (string name in names)
                    {
                        writer.WriteLine(name);
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
