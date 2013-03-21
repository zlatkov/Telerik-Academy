using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Represents the bullet which the players can shoot. 
    /// </summary>
    public class Bullet : MovingObject
    {
        public new const string CollisionGroupString = "bullet";
        public const int Damage = 25;  //The damage done by a bullet.

        public Bullet(GridPosition position, ObjectColor color, GridPosition direction)
            : base(position, '+', color, direction)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            //The bullets can collide with anything except other bullets.
            return otherCollisionGroupString != "bullet";
        }

        public override string GetCollisionGroupString()
        {
            return Bullet.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.Direction = new GridPosition(0, 0);
            this.IsDestroyed = true;
        }
    }
}
