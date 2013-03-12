using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.TimerEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(10, 1000);
            timer.TimerTick += OnTimerTick;
            timer.Start();
        }

        static void OnTimerTick(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Inside timer tick, ticks left: " + e.TicksLeft);
        }
    }
}
