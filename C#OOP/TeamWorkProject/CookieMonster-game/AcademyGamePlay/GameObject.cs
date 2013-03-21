using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// The base class of all moving objects in the game.
    /// </summary>
    public abstract class GameObject : IRenderable, ICollidable, IProducable<GameObject>
    {
        public const string CollisionGroupString = "gameObject";

        protected GridPosition position; //The position of the object.
        protected char image; //The char value that represents the object.
        protected ObjectColor color;  //The color of the object.

        /// <summary>
        /// Creates a game object.
        /// </summary>
        /// <param name="position">The position of the object.</param>
        /// <param name="image">The image which will represent the object.</param>
        /// <param name="color">The color of the object.</param>
        protected GameObject(GridPosition position, char image, ObjectColor color)
        {
            this.position = position;
            this.image = image;
            this.color = color;

            this.IsDestroyed = false;
        }

        /// <summary>
        /// Gets the position of the object.
        /// </summary>
        public GridPosition Position
        {
            protected set
            {
                //Makes a a copy of the new position.
                this.position = new GridPosition(value.X, value.Y); 
            }
            get
            {
                //Creates a copy of the current position.
                return new GridPosition(this.position.X, this.position.Y);
            }
        }

        /// <summary>
        /// Gets the state if the object is destroyed or not.
        /// </summary>
        public bool IsDestroyed { get; protected set; }

        /// <summary>
        /// Updates the state of the object.
        /// </summary>
        public abstract void Update();

        public virtual void RespondToCollision(CollisionData collisionData)
        {
        }

        public virtual bool CanCollideWith(string otherCollisionGroupString)
        {
            return GameObject.CollisionGroupString == otherCollisionGroupString;
        }

        public virtual string GetCollisionGroupString()
        {
            return GameObject.CollisionGroupString;
        }

        public virtual GridPosition GetObjectPosition()
        {
            return this.position;
        }

        public virtual ObjectColor GetObjectColor()
        { 
            return this.color;
        }

        public virtual char GetObjectImage()
        {
            return this.image;
        }

        public virtual IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject>();
        }

        public static bool operator ==(GameObject a, GameObject b)
        {
            return GameObject.Equals(a, b);
        }

        public static bool operator !=(GameObject a, GameObject b)
        {
            return !GameObject.Equals(a, b);
        }

        public override bool Equals(object obj)
        {
            GameObject other = obj as GameObject;
            if (other == null)
            {
                return false;
            }
            else
            {
                return this.GetObjectPosition() == other.GetObjectPosition()
                    && this.GetObjectImage() == other.GetObjectImage()
                    && this.GetObjectColor() == other.GetObjectColor();
            }
        }

        public override int GetHashCode()
        {
            return ((this.GetObjectPosition().GetHashCode() << 16) | (this.GetObjectImage().GetHashCode() & 0xffff)) ^ this.GetObjectColor().GetHashCode();
        }
    }
}
