using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HtmlFileParser
{
    class HtmlFileParser
    {
        static void Main(string[] args)
        {
            string fileName = Console.ReadLine();

            using (StreamReader reader = new StreamReader(fileName))
            {
                bool insideTagDeclaration = false;
                string line = reader.ReadLine();

                StringBuilder result = new StringBuilder();
                StringBuilder lineText = new StringBuilder();
                string lineString;

                while (line != null)
                {
                    lineText.Clear();
                    foreach (char symbol in line)
                    {
                        if (insideTagDeclaration)
                        {
                            if (symbol == '>')
                            {
                                insideTagDeclaration = false;
                            }
                        }
                        else
                        {
                            if (symbol == '<')
                            {
                                lineText.Append(" ");
                                insideTagDeclaration = true;
                            }
                            else
                            {
                                lineText.Append(symbol);
                            }
                        }
                    }

                    lineString = lineText.ToString().Trim();
                    if (lineString != String.Empty)
                    {
                        result.Append(lineString);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }

                Console.WriteLine(result.ToString());
            }
        }
    }
}
