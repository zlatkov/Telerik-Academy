using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Describes a timer.
    /// </summary>
    public class Timer
    {
        private DateTime lastUpdate; //The date at which the timer was last updated.
        private bool shouldTick;     //If the timer should tick.

        public EventHandler OnTimerFinished; //The event is dispatched when the timer finishes.

        public Timer(int seconds)
        {
            this.SecondsLeft = seconds;
            this.SecondsTotal = seconds;
        }

        /// <summary>
        /// Gets the seconds which are left for the timer.
        /// </summary>
        public int SecondsLeft { private set; get; }

        /// <summary>
        /// Gets the total number of seconds which the timer has to work.
        /// </summary>
        public int SecondsTotal { private set; get; }

        /// <summary>
        /// Updates the date of the timer.
        /// </summary>
        public void Update()
        {
            if (this.SecondsLeft > 0)
            {
                DateTime current = DateTime.Now;

                //If the new date is atlest 1 second after the last update.
                if (lastUpdate == null || Math.Abs(current.Second - lastUpdate.Second) > 0)
                {
                    this.shouldTick = true;
                    this.lastUpdate = current;
                }
            }
        }

        /// <summary>
        /// Checks if the timer has to finish.
        /// </summary>
        public void Check()
        {
            //If the timer has to tick.
            if (this.shouldTick)
            {
                this.shouldTick = false;
                this.SecondsLeft--;
            }

            //If the timer's time has finished.
            if (this.SecondsLeft <= 0)
            {
                EventHandler handler = OnTimerFinished;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
        }

    }
}
