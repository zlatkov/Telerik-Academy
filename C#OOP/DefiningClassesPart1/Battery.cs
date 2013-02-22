using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.GSMCallHistoryTest
{
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
}
