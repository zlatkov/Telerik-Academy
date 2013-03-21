using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// All objects which can produce other objects will implement this interface.
    /// </summary>
    public interface IProducable<T>
    {
        /// <summary>
        /// Returns the objects which are produced by the object.
        /// </summary>
        IEnumerable<T> ProduceObjects();
    }
}
