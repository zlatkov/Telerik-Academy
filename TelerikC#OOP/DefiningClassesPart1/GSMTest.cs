using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.GSMCallHistoryTest
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            GSM gsm = new GSM("testModel", "testManufacturer");

            gsm.AddCall(new Call("11.02.2013", "18:32", "00000000", 432));
            gsm.AddCall(new Call("11.02.2013", "19:02", "00000001", 23));
            gsm.AddCall(new Call("12.02.2013", "11:28", "00000010", 5243));

            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine("Call date: " + call.Date);
                Console.WriteLine("Call time: " + call.Time);
                Console.WriteLine("Call phone number: " + call.PhoneNumber);
                Console.WriteLine("Call duration: " + call.Duration);
                Console.Write("\n");
            }

            Console.WriteLine("Total price: " + gsm.TotalPrice(0.37m));

            gsm.DeleteCall(2);

            Console.WriteLine("Total price without the longest call: " + gsm.TotalPrice(0.37m));
            Console.Write("\n");

            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine("Call date: " + call.Date);
                Console.WriteLine("Call time: " + call.Time);
                Console.WriteLine("Call phone number: " + call.PhoneNumber);
                Console.WriteLine("Call duration: " + call.Duration);
                Console.Write("\n");
            }

            gsm.ClearCallHistory();

            foreach (Call call in gsm.CallHistory)
            {
                Console.WriteLine("Call date: " + call.Date);
                Console.WriteLine("Call time: " + call.Time);
                Console.WriteLine("Call phone number: " + call.PhoneNumber);
                Console.WriteLine("Call duration: " + call.Duration);
                Console.Write("\n");
            }
        }
    }
}
