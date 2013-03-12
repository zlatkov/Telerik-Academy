using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _8.TimerEvents
{
    public class Timer
    {
        public event TimerTickEventHandler TimerTick;

        public Timer(int ticksCount, int interval)
        {
            this.Interval = interval;
            this.TicksCount = ticksCount;
        }

        public int TicksCount { private set; get; }
        public int Interval { private set; get; }

        protected virtual void OnTimerTick(TimerEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            TimerTickEventHandler handler = TimerTick;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void Start()
        {
            int ticksLeft = this.TicksCount;
            while (ticksLeft > 0)
            {
                Thread.Sleep(this.Interval);
                ticksLeft--;
                OnTimerTick(new TimerEventArgs(ticksLeft));
            }
        }
    }
}
