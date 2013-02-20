using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.GSMCallHistoryTest
{
    public class Display
    {
        public Display()
        {
        }

        public Display(float size, uint numberOfColors)
        {
            Size = size;
            NumberOfColors = numberOfColors;
        }

        public Display(float size)
        {
            Size = size;
        }

        public Display(uint numberOfCOlors)
        {
            NumberOfColors = NumberOfColors;
        }

        public float? Size { get; set; }
        public uint? NumberOfColors { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Display size: " + Size + "\n");
            result.Append("Display number of colors: " + NumberOfColors + "\n");

            return result.ToString();
        }
    }
}
