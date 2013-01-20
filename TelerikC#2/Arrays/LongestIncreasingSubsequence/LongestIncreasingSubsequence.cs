using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence
{
    class LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] sequence = new int[n];
            int[] dp = new int[n];
            int[] previous = new int[n];

            for (int i = 0; i < n; ++i)
            {
                sequence[i] = int.Parse(Console.ReadLine());

                dp[i] = 1;
                previous[i] = -1;  
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if (sequence[j] >= sequence[i] && dp[i] + 1 > dp[j])
                    {
                        dp[j] = dp[i] + 1;
                        previous[j] = i;
                    }
                }
            }

            int maxValueIndex = 0;
            for (int i = 1; i < n; ++i)
            {
                if (dp[i] > dp[maxValueIndex])
                {
                    maxValueIndex = i;
                }
            }

            int[] result = new int[dp[maxValueIndex]];

            int resultLength = dp[maxValueIndex];
            int resultPosition = dp[maxValueIndex] - 1;

            int current = maxValueIndex;
            while (current != -1)
            {
                result[resultPosition] = sequence[current];
                current = previous[current];
                resultPosition--;
            }

            for (int i = 0; i < resultLength; ++i)
            {
                if (i > 0)
                {
                    Console.Write(" ");
                }
                Console.Write(result[i]);
            }
            Console.Write("\n");
        }
    }
}
