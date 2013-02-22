using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace InsertLineNumbers
{
    class InsertLineNumbers
    {
        static void Main(string[] args)
        {

            Console.Write("Enter input file name: ");
            string inputFileName = Console.ReadLine();

            Console.Write("Enter output file name: ");
            string outputFileName = Console.ReadLine();

            try
            {
                StringBuilder newContent = new StringBuilder("");
                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    int lineNumber = 1;
                    string currentLine = reader.ReadLine();

                    while (currentLine != null)
                    {
                        newContent.Append(lineNumber + " " + currentLine + "\n");
                        currentLine = reader.ReadLine();
                        lineNumber++;
                    }
                }

                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.Write(newContent.ToString());
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
