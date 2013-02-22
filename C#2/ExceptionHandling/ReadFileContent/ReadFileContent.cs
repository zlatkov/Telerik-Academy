using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security;

namespace ReadFileContent
{
    class ReadFileContent
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = Console.ReadLine();
                string fileContent = File.ReadAllText(filePath);

                Console.WriteLine(fileContent);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("The file path is null.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("The file path contains invalid characters");
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine("The file path is too long.");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The directory was not found.");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file in the specified path was not found.");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occured whille opening the file");
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("The path is in an invalid format.");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("The path cannot be opened.");
            }
            catch (SecurityException e)
            {
                Console.WriteLine("You don't have the required permission to open this file.");
            }
        }
    }
}
