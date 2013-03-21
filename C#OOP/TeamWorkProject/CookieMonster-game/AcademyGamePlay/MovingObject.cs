using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Defines a moving object in the game. All moving object should inherit the MovingObject class.
    /// </summary>
    public class MovingObject : GameObject
    {
        public MovingObject(GridPosition position, char image, ObjectColor color)
            : base(position, image, color)
        {
            this.Direction = new GridPosition(0, 0);  
        }

        public MovingObject(GridPosition position, char image, ObjectColor color, GridPosition direction)
            : base(position, image, color)
        {
            this.Direction = direction;
        }

        /// <summary>
        /// Gets the direction of the moving object.
        /// </summary>
        public GridPosition Direction { protected set; get; }

        /// <summary>
        /// Updates the position of the moving object.
        /// </summary>
        public override void Update()
        {
            this.Position += this.Direction;
        }
    }
}
