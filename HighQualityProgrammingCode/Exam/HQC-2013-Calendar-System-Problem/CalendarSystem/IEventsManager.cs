// <copyright file="IEventsManager.cs" company="None">
// All rights not reserved.
// </copyright>
// <author>Alexander Zlatkov</author>
namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Interface for classes which can store, delete and list events.
    /// </summary>
    public interface IEventsManager
    {
        /// <summary>
        /// Adds the event <paramref name="newEvent"/>.
        /// </summary>
        /// <param name="newEvent">The event to be added.</param>
        void AddEvent(Event newEvent);

        /// <summary>
        /// Deletes all events which have title equal to <paramref name="title"/>.
        /// </summary>
        /// <param name="title">The title of the events to be deleted.</param>
        /// <returns>The number of deleted events.</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Returns all events starting from <paramref name="date"/>.
        /// The number of the returned events will be <paramref name="numberOfEventsToList"/> 
        /// or less if not enough events are available.
        /// </summary>
        /// <param name="date">The starting date of the events.</param>
        /// <param name="numberOfEventsToList">The number of events to return.</param>
        /// <returns>An <see cref="System.Collections.Generic.IEnumerable{Event}"/>
        /// of events starting from <paramref name="date"/>.
        /// </returns>
        IEnumerable<Event> ListEvents(DateTime startingDate, int numberOfEventsToList);
    }
}
