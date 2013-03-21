using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// All objects which are going to be rendered on the screed will implement this interface.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Returns the position of the object.
        /// </summary>
        GridPosition GetObjectPosition();

        /// <summary>
        /// Returns the image of the object.
        /// </summary>
        char GetObjectImage();

        /// <summary>
        /// Returns the color of the object.
        /// </summary>
        ObjectColor GetObjectColor();
    }
}
