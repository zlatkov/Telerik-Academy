using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.TimerEvents
{
    public delegate void TimerTickEventHandler(object sender, TimerEventArgs e);

    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(int ticksLeft)
        {
            this.TicksLeft = ticksLeft;
        }

        public int TicksLeft { private set; get; }
    }
}
