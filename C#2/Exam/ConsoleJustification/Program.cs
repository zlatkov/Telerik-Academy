using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJustification
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int maxWidth = int.Parse(Console.ReadLine());

            List<string> words = new List<string>();
            for (int i = 0; i < numberOfLines; ++i)
            {
                string lineText = Console.ReadLine();
                string[] parts = lineText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                foreach(var part in parts)
                {
                    words.Add(part);
                }
            }

            List<string> line = new List<string>();
            StringBuilder result = new StringBuilder();

            int currentSum = 0;
            foreach (var word in words)
            {
                if (currentSum == 0)
                {
                    currentSum += word.Length;
                    line.Add(word);
                }
                else if (currentSum + 1 + word.Length <= maxWidth)
                {
                    currentSum += 1 + word.Length;
                    line.Add(word);
                }
                else
                {
                    if (line.Count == 1)
                    {
                        result.Append(line[0]);
                        result.AppendLine();
                    }
                    else
                    {
                        int left = maxWidth - currentSum;
                        result.Append(line[0]);

                        if (line.Count - 1 >= left)
                        {
                            for (int i = 1; i < line.Count; ++i)
                            {
                                if (left > 0)
                                {
                                    result.Append(" ");
                                    left--;
                                }
                                result.Append(" ");
                                result.Append(line[i]);
                            }
                            result.AppendLine();
                        }
                        else
                        {
                            int spacesToAdd = left / (line.Count - 1);
                            int begAdd = left % (line.Count - 1);


                            result.Append(' ', spacesToAdd);
                            if (begAdd > 0)
                            {
                                result.Append(" ");
                                begAdd--;
                            }
                            result.Append(" ");

                            for (int i = 1; i < line.Count - 1; ++i)
                            {
                                result.Append(line[i]);
                                result.Append(' ', spacesToAdd);
                                if (begAdd > 0)
                                {
                                    result.Append(" ");
                                    begAdd--;
                                }
                                result.Append(" ");
                            }
                            result.Append(line[line.Count - 1]);
                            result.AppendLine();
                        }
                    }

                    currentSum = word.Length;
                    line.Clear();
                    line.Add(word);
                }
            }

            //Repeating..... no time to make the code without copy-paste :(
            if (line.Count > 0)
            {
                if (line.Count == 1)
                {
                    result.Append(line[0]);
                    result.AppendLine();
                }
                else
                {
                    int left = maxWidth - currentSum;
                    result.Append(line[0]);

                    if (line.Count - 1 >= left)
                    {
                        for (int i = 1; i < line.Count; ++i)
                        {
                            if (left > 0)
                            {
                                result.Append(" ");
                                left--;
                            }
                            result.Append(" ");
                            result.Append(line[i]);
                        }
                        result.AppendLine();
                    }
                    else
                    {
                        int spacesToAdd = left / (line.Count - 1);
                        int begAdd = left % (line.Count - 1);


                        result.Append(' ', spacesToAdd);
                        if (begAdd > 0)
                        {
                            result.Append(" ");
                            begAdd--;
                        }
                        result.Append(" ");

                        for (int i = 1; i < line.Count - 1; ++i)
                        {
                            result.Append(line[i]);
                            result.Append(' ', spacesToAdd);
                            if (begAdd > 0)
                            {
                                result.Append(" ");
                                begAdd--;
                            }
                            result.Append(" ");
                        }
                        result.Append(line[line.Count - 1]);
                        result.AppendLine();
                    }
                }
            } 

            Console.Write(result.ToString());
        }
    }
}
