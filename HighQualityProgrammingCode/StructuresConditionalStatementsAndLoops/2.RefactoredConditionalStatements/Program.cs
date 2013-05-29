using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.RefactoredConditionalStatements
{
    class Program
    {
        private static bool IsInRange(int currentValue, int minValue, int maxValue)
        {
            if (currentValue < minValue || maxValue < currentValue)
            {
                return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            Potato potato = new Potato();
            if (potato != null)
            {
                if (!potato.IsRotten && potato.HasBeenPeeled)
                {
                    Cook(potato);
                }
            }

            if (IsInRange(x, MIN_X, MAX_X) && IsInRange(y, MIN_Y, MAX_Y) && shouldVisitCell)
            {
                VisitCell(x, y);
            }
        }
    }
}
