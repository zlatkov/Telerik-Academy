using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.GSMCallHistoryTest
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private List<Call> callHistory = new List<Call>();

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

        public List<Call> CallHistory
        {
            get
            {
                return callHistory;
            }
        }

        public void AddCall(Call call)
        {
            CallHistory.Add(call);
        }

        public void DeleteCall(int callIndex)
        {
            if (callIndex >= 0 && callIndex < CallHistory.Count)
            {
                CallHistory.RemoveAt(callIndex);
            }
        }

        public void ClearCallHistory()
        {
            CallHistory.Clear();
        }

        public decimal TotalPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0m;
            foreach (Call call in CallHistory)
            {
                totalPrice += (decimal)(call.Duration / 60) * pricePerMinute;
                if (call.Duration % 60 > 0)
                {
                    totalPrice += pricePerMinute;
                }
            }

            return totalPrice;
        }

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
}
