using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Describes a wall in the game. Tha wall is indestructible.
    /// </summary>
    class Wall : StaticObject
    {
        public new const string CollisionGroupString = "wall";

        public Wall(GridPosition position, ObjectColor color = ObjectColor.Gray)
            : base(position, '.', color)
        {
        }

        public override string GetCollisionGroupString()
        {
            return Wall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
        }
    }
}
