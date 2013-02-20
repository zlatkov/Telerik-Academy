using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.GSMCallHistoryTest
{
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
}
