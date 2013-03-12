using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace _7.Timer
{
    public delegate void TimerDelegate();

    public class Timer
    {
        private TimerDelegate methodToCall;

        public Timer(TimerDelegate methodToCall, int ticksCount, int interval)
        {
            this.methodToCall = methodToCall;
            this.TicksCount = ticksCount;
            this.Interval = interval;
        }

        public int TicksCount { private set; get; }
        public int Interval { private set; get; }

        public void Start()
        {
            int ticksLeft = this.TicksCount;
            while (ticksLeft > 0)
            {
                Thread.Sleep(this.Interval);
                this.methodToCall();
                ticksLeft--;
            }
        }
    }
}
