namespace CalendarSystem
{
    using System;
    using System.Linq;
    using System.Text;

    public class Event : IComparable<Event>
    {
        public Event(DateTime date, string title)
            : this(date, title, null)
        {
        }

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; private set; }

        public string Title { get; private set; }

        public string Location { get; private set; }

        public override string ToString()
        {
            StringBuilder form = new StringBuilder();
            form.Append("{0:yyyy-MM-ddTHH:mm:ss} | {1}");
            if (this.Location != null)
            {
                form.Append(" | {2}");
            }

            string eventAsString = string.Format(form.ToString(), this.Date, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(Event other)
        {
            int compareDates = DateTime.Compare(this.Date, other.Date);
            if (compareDates != 0)
            {
                return compareDates;
            }

            int compareTitles = this.Title.CompareTo(other.Title);
            if (compareTitles != 0)
            {
                return compareTitles;
            }

            int compareLocations = string.Compare(this.Location, other.Location, StringComparison.InvariantCulture);
            if (compareLocations < 0)
            {
                return -1;
            }
            else if (compareLocations > 0)
            {
                return 1;
            }

            return 0;
        }
    }
}
