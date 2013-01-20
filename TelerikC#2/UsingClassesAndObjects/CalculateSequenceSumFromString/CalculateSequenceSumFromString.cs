using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSequenceSumFromString
{
    class CalculateSequenceSumFromString
    {
        static int CalculateSequenceSum(string sequenceString)
        {
            string[] values = sequenceString.Split(' ');

            int sum = 0;
            foreach (string value in values)
            {
                sum += int.Parse(value);
            }
            return sum;
        }

        static void Main(string[] args)
        {
            string sequenceString = Console.ReadLine();

            int sum = CalculateSequenceSum(sequenceString);

            Console.WriteLine(sum);
        }
    }
}
