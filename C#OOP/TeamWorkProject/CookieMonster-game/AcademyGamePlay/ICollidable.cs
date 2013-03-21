using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// All objects which can collide will implement this interface.
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// Checks if the object can collide with the given object collision group string.
        /// </summary>
        bool CanCollideWith(string objectCollisionGroupString);

        /// <summary>
        /// How the object responds to a collision.
        /// </summary>
        void RespondToCollision(CollisionData collisionData);

        /// <summary>
        /// Returns the collision group string of the object.
        /// </summary>
        string GetCollisionGroupString();
    }
}
