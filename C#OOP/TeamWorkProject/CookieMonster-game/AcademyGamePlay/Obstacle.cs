using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Describes an obstacle in the game. The obstacles must be destroyed in order to move through them.
    /// </summary>
    public class Obstacle : StaticObject
    {
        public Obstacle(GridPosition position, ObjectColor color)
            : base(position, '#', color)
        {
        }
    }
}
