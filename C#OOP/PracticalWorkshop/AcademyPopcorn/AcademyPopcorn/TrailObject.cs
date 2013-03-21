using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        public new const string CollisionGroupString = "trailObject";

        private int lifeTime;

        public TrailObject(MatrixCoords topLeft, int lifeTime)
            : base(topLeft, new char[,] { { '*' } })
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            if (this.lifeTime > 0)
            {
                this.lifeTime--;
            }
            if (this.lifeTime == 0)
            {
                this.IsDestroyed = true;
            }
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Block.CollisionGroupString;
        }
    }
}
