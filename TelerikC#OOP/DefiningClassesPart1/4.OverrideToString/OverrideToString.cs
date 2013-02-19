using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.OverrideToString
{
    class OverrideToString
    {
        public enum BatteryType : byte { LiLon, NiMH, NiCd };

        public class Battery
        {
            public Battery(string model)
            {
                Model = model;
            }

            public Battery(string model, BatteryType type)
            {
                Model = model;
                Type = type;
            }

            public Battery(string model, ushort hoursIdle, ushort hoursTalk, BatteryType type)
            {
                Model = model;
                HoursIdle = hoursIdle;
                HoursTalk = hoursTalk;
                Type = type;
            }

            public string Model { get; set; }
            public ushort? HoursIdle { get; set; }
            public ushort? HoursTalk { get; set; }
            public BatteryType Type { get; set; }

            public override string ToString()
            {
                StringBuilder result = new StringBuilder();
                result.Append("Battery model: " + Model + "\n");
                result.Append("Battery hours idle: " + HoursIdle + "\n");
                result.Append("Battery hours talk: " + HoursTalk + "\n");
                result.Append("Battery type: ");

                switch (Type)
                {
                    case BatteryType.LiLon: result.Append("LiLon\n"); break;
                    case BatteryType.NiCd: result.Append("NiCD\n"); break;
                    case BatteryType.NiMH: result.Append("NiMH\n"); break;
                    default: result.Append("unknown\n"); break;
                }

                return result.ToString();
            }
        }

        public class Display
        {
            public Display()
            {
            }

            public Display(byte size, uint numberOfColors)
            {
                Size = size;
                NumberOfColors = numberOfColors;
            }

            public Display(byte size)
            {
                Size = size;
            }

            public Display(uint numberOfCOlors)
            {
                NumberOfColors = NumberOfColors;
            }

            public byte? Size { get; set; }
            public uint? NumberOfColors { get; set; }

            public override string ToString()
            {
                StringBuilder result = new StringBuilder();
                result.Append("Display size: " + Size + "\n");
                result.Append("Display number of colors: " + NumberOfColors + "\n");

                return result.ToString();
            }
        }

        public class GSM
        {
            public GSM(string model, string manufacturer, decimal price, string owner, Battery batteryCharacteristics, Display displayCharacteristics)
            {
                Model = model;
                Manufacturer = manufacturer;
                Price = price;
                Owner = owner;
                BatteryCharacteristics = batteryCharacteristics;
                DisplayCharacteristics = displayCharacteristics;
            }

            public GSM(string model, string manufacturer)
            {
                Model = model;
                Manufacturer = manufacturer;
            }

            public string Model { get; set; }
            public string Manufacturer { get; set; }
            public decimal? Price { get; set; }
            public string Owner { get; set; }

            public Battery BatteryCharacteristics { get; set; }
            public Display DisplayCharacteristics { get; set; }

            public override string ToString()
            {
                StringBuilder result = new StringBuilder();

                result.Append("GSM Model: " + Model + "\n");
                result.Append("GSM Manufacturer: " + Manufacturer + "\n");
                result.Append("GSM Price: " + Price + "\n");
                result.Append("GSM Owner: " + Owner + "\n");
                result.Append(BatteryCharacteristics.ToString());
                result.Append(DisplayCharacteristics.ToString());

                return result.ToString();
            }
        }

        static void Main(string[] args)
        {
            Display display = new Display(53, 432423);
            Battery battery = new Battery("test model", 32, 9, BatteryType.NiCd);
            GSM gsm = new GSM("3310", "Nokia", 10321.321m, "Alexander Zlatkov", battery, display);

            Console.WriteLine(gsm.ToString());
        }
    }
}
