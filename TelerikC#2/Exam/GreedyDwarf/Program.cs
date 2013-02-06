using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyDwarf
{
    class Program
    {
        static List<int> ReadSequence()
        {
            string line = Console.ReadLine();
            string[] splitted = line.Split(new string[] { ", " }, StringSplitOptions.None);

            List<int> result = new List<int>();
            foreach (var split in splitted)
            {
                result.Add(int.Parse(split));
            }

            return result;
        }

        static int Calculate(List<int> valley, List<int> pattern)
        {
            int result = 0;
            int position = 0;
            int patternPosition = 0;
            bool[] visited = new bool[valley.Count];

            while (position >= 0 && position < valley.Count && !visited[position])
            {
                visited[position] = true;
                result += valley[position];
                position += pattern[patternPosition];
                patternPosition = (patternPosition + 1) % pattern.Count;
            }
            return result;
        }

        static void Main(string[] args)
        {
            List<int> valley = ReadSequence();

            int patternsCount = int.Parse(Console.ReadLine());
            int result = int.MinValue;

            for (int i = 0; i < patternsCount; ++i)
            {
                List<int> pattern = ReadSequence();

                int tmpResult = 0;
                int position = 0;
                int patternPosition = 0;
                bool[] visited = new bool[valley.Count];

                while (position >= 0 && position < valley.Count && !visited[position])
                {
                    visited[position] = true;
                    tmpResult += valley[position];
                    position += pattern[patternPosition];
                    patternPosition = (patternPosition + 1) % pattern.Count;
                }

                result = Math.Max(result, tmpResult);
            }

            Console.WriteLine(result);

        }
    }
}
