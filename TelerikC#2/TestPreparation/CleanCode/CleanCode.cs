using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CleanCode
{
    class CleanCode
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            bool inMultiLineComment = false;
            bool inString = false;
            bool inThreeSlashes = false;
            bool inQuotedString = false;
            bool inSingleQuotedString = false;

            for (int linePos = 0; linePos < n; ++linePos)
            {
                string line = Console.ReadLine();

                inThreeSlashes = false;

                for (int i = 0; i < line.Length; ++i)
                {
                    if (inThreeSlashes)
                    {
                        result.Append(line[i]);
                        continue;
                    }
                    else if (inMultiLineComment)
                    {
                        if (i < line.Length - 1 && line[i] == '*' && line[i + 1] == '/')
                        {
                            i++;
                            inMultiLineComment = false;
                        }
                    }
                    else if (inSingleQuotedString)
                    {
                        if (line[i] == '\\')
                        {
                            result.Append('\\');
                            result.Append(line[i + 1]);
                            i++;
                        }
                        else if (line[i] == '\'')
                        {
                            result.Append('\'');
                            inSingleQuotedString = false;
                        }
                        else
                        {
                            result.Append(line[i]);
                        }
                    }
                    else if (inQuotedString)
                    {
                        if (line[i] == '\"')
                        {
                            inQuotedString = false;
                        }

                        result.Append(line[i]);
                        if (line[i] == '\"' && i < line.Length - 1 && line[i + 1] == '\"')
                        {
                            inQuotedString = true;
                            result.Append(line[i + 1]);
                            i++;
                        }
                    }
                    else if (inString)
                    {
                        if (line[i] == '\\')
                        {
                            result.Append('\\');
                            result.Append(line[i + 1]);
                            i++;
                            continue;
                        }
                        else if (line[i] == '\"')
                        {
                            inString = false;
                        }
                        result.Append(line[i]);
                    }
                    else
                    {
                        if (line[i] == '\"')
                        {
                            inString = true;
                            result.Append('\"');
                        }
                        else if (line[i] == '@')
                        {
                            inQuotedString = true;
                            result.Append('@');
                            result.Append(line[i + 1]);
                            i++;
                        }
                        else if (line[i] == '\'')
                        {
                            inSingleQuotedString = true;
                            result.Append('\'');
                        }
                        else if (i < line.Length - 1 && line[i] == '/' && line[i + 1] == '/')
                        {
                            if (i < line.Length - 2 && line[i + 2] == '/')
                            {
                                result.Append("///");
                                inThreeSlashes = true;
                                i += 2;
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (i < line.Length - 1 && line[i] == '/' && line[i + 1] == '*')
                        {
                            inMultiLineComment = true;
                        }
                        else
                        {
                            result.Append(line[i]);
                        }
                    }
                }

                if (!inMultiLineComment)
                {
                    result.AppendLine();
                }
            }

            StringReader reader = new StringReader(result.ToString());
            string lineToPrint = null;
            while ((lineToPrint = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(lineToPrint))
                {
                    Console.WriteLine(lineToPrint);
                }
            }
        }
    }
}
