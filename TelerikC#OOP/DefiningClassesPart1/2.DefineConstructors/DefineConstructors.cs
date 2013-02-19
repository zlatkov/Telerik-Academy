using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.DefineConstructors
{
    public class Battery
    {
        public Battery(string model)
        {
            Model = model;
        }

        public Battery(string model, ushort hoursIdle, ushort hoursTalk)
        {
            Model = model;
            HoursIdle = hoursIdle;
            HoursTalk = hoursTalk;
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
    }

    class DefineConstructors
    {
        static void Main(string[] args)
        {
        }
    }
}
