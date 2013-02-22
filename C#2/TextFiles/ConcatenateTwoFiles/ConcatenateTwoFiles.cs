using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace ConcatenateTwoFiles
{
    class ConcatenateTwoFiles
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the first file name: ");
            string firstFileName = Console.ReadLine();
            
            Console.Write("Enter the second file name: ");
            string secondFileName = Console.ReadLine();

            Console.Write("Enter the output file name: ");
            string outputFileName = Console.ReadLine();

            try
            {
                string firstFileContent = "";
                string secondFileContent = "";
                using (StreamReader firstReader = new StreamReader(firstFileName))
                {
                    firstFileContent = firstReader.ReadToEnd();
                }
                using (StreamReader secondReader = new StreamReader(secondFileName))
                {
                    secondFileContent = secondReader.ReadToEnd();
                }
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(firstFileContent);
                    writer.WriteLine(secondFileContent);
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
