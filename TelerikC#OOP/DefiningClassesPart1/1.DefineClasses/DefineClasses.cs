using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DefineClasses
{
    public class Battery
    {
        public Battery()
        {
        }

        public string Model { get; set; }
        public ushort? HoursIdle { get; set; }
        public ushort? HoursTalk { get; set; }
    }

    public class Display
    {
        public Display()
        {
        }

        public byte? Size { get; set; }
        public uint? NumberOfColors { get; set; }
    }

    public class GSM
    {
        public GSM()
        {
        }

        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public decimal? Price { get; set; }
        public string Owner { get; set; }

        public Battery BatteryCharacteristics { get; set; }
        public Display DisplayCharacteristics { get; set; }
    }

    class DefineClasses
    {
        static void Main(string[] args)
        {
            GSM gsm = new GSM();
        }
    }
}
