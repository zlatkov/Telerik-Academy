using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Manages the collisions in the game.
    /// </summary>
    public static class CollisionDispatcher
    {
        /// <summary>
        /// Checks if there are collision between the objects in the game.
        /// If collisions are found, then the ResponceToCollision methods are called for the objects
        /// which collide.
        /// </summary>
        public static void HandleCollisions(List<GameObject> staticObjects, List<MovingObject> movingObjects)
        {
            HandleStaticWithMovingCollisions(staticObjects, movingObjects);
            HandleMovingWithMovingCollisions(movingObjects);
        }

        /// <summary>
        /// Checks for collisions between the static and the moving objects in the game.
        /// </summary>
        private static void HandleStaticWithMovingCollisions(List<GameObject> staticObjects, List<MovingObject> movingObjects)
        {
            foreach (var movingObject in movingObjects)
            {
                foreach (var staticObject in staticObjects)
                {
                    if (movingObject.CanCollideWith(staticObject.GetCollisionGroupString())
                        || staticObject.CanCollideWith(movingObject.GetCollisionGroupString()))
                    {
                        if ((movingObject.Position + movingObject.Direction) == staticObject.Position 
                            || movingObject.Position == staticObject.Position)
                        {
                            movingObject.RespondToCollision(new CollisionData(
                                staticObject.GetObjectImage(),
                                staticObject.GetCollisionGroupString())
                                );

                            staticObject.RespondToCollision(new CollisionData(
                                movingObject.GetObjectImage(),
                                movingObject.GetCollisionGroupString())
                                );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks for collisions between the moving objects in the game.
        /// </summary>
        private static void HandleMovingWithMovingCollisions(List<MovingObject> movingObjects)
        {
            foreach (var firstMovingObject in movingObjects)
            {
                foreach (var secondMovingObject in movingObjects)
                {
                    //We shouldnt compare an object with itself.
                    if (firstMovingObject != secondMovingObject)
                    {
                        //If one of the object moves and overlaps with the other object, then a collision is found.
                        if (firstMovingObject.CanCollideWith(secondMovingObject.GetCollisionGroupString())
                            || secondMovingObject.CanCollideWith(firstMovingObject.GetCollisionGroupString()))
                        {
                            if ((firstMovingObject.Position + firstMovingObject.Direction) == secondMovingObject.Position
                                || (secondMovingObject.Position + secondMovingObject.Direction) == firstMovingObject.Position)
                            {
                                firstMovingObject.RespondToCollision(new CollisionData(
                                    secondMovingObject.GetObjectImage(),
                                    secondMovingObject.GetCollisionGroupString())
                                    );

                                secondMovingObject.RespondToCollision(new CollisionData(
                                    firstMovingObject.GetObjectImage(),
                                    firstMovingObject.GetCollisionGroupString())
                                    );
                            }
                        }
                    }
                }
            }
        }
    }
}
