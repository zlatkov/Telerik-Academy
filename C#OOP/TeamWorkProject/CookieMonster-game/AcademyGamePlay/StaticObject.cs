using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Defines a static object in the game. All static object should inherit the StaticObject class.
    /// </summary>
    public class StaticObject : GameObject
    {
        public StaticObject(GridPosition position, char image, ObjectColor color)
            : base(position, image, color)
        {
        }

        public override void Update()
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "bullet";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.ObjectCollisionGroupString == "bullet")
            {
                this.IsDestroyed = true;
            }
        }
    }
}
