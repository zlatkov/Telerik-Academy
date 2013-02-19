using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.CallClass
{
    class CallClass
    {
        public enum BatteryType : byte { LiLon, NiMH, NiCd };

        public class Battery
        {
            private string model;

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

            public string Model
            {
                get
                {
                    return model;
                }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        model = value;
                    }
                    else
                    {
                        throw new ArgumentException("The model value of the Battery class is null or empty.");
                    }
                }
            }

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

        public class GSM
        {
            private string model;
            private string manufacturer;

            private static GSM iPhone4S = new GSM("4S", "iPhone", 2000, "Chris Cornell", new Battery("A1303", BatteryType.LiLon), new Display(3.5f, 800000));


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

            public static GSM IPhone4S
            {
                get
                {
                    return iPhone4S;
                }
                set
                {
                    iPhone4S = value;
                }
            }

            public string Model
            {
                get
                {
                    return model;
                }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        model = value;
                    }
                    else
                    {
                        throw new ArgumentException("The Model value of the GSM class is null or empty.");
                    }
                }
            }

            public string Manufacturer
            {
                get
                {
                    return manufacturer;
                }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        manufacturer = value;
                    }
                    else
                    {
                        throw new ArgumentException("The Manufacturer value of the GSM class is null or empty.");
                    }
                }
            }

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

                if (BatteryCharacteristics != null)
                {
                    result.Append(BatteryCharacteristics.ToString());
                }
                if (DisplayCharacteristics != null)
                {
                    result.Append(DisplayCharacteristics.ToString());
                }

                return result.ToString();
            }
        }

        public class Call
        {
            public Call(string date, string time, string phoneNumber, uint duration)
            {
                Date = date;
                Time = time;
                PhoneNumber = phoneNumber;
                Duration = duration;
            }

            public string Date { get; set; }
            public string Time { get; set; }
            public string PhoneNumber { get; set; }
            public uint Duration { get; set; }
        }


        static void Main(string[] args)
        {
        }
    }
}
