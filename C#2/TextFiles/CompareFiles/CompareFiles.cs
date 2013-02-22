using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompareFiles
{
    class CompareFiles
    {
        static void Main(string[] args)
        {
            string firstFileName = Console.ReadLine();
            string secondFileName = Console.ReadLine();

            try
            {
                using (StreamReader firstReader = new StreamReader(firstFileName))
                {
                    using (StreamReader secondRreader = new StreamReader(secondFileName))
                    {
                        string firstLine = firstReader.ReadLine();
                        string secondLine = secondRreader.ReadLine();

                        int equalLines = 0, differentLines = 0;
                        while (firstLine != null && secondLine != null)
                        {
                            if (firstLine == secondLine)
                            {
                                equalLines++;
                            }
                            else
                            {
                                differentLines++;
                            }

                            firstLine = firstReader.ReadLine();
                            secondLine = secondRreader.ReadLine();
                        }

                        Console.WriteLine("Number of equal lines: " + equalLines);
                        Console.WriteLine("Number of different lines: " + differentLines);
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
