using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingWave : Ball
    {
        public new const string CollisionGroupString = "ball";

        public ExplodingWave(MatrixCoords topLeft)
            : base(topLeft, new MatrixCoords(0, 0))
        {
            this.body[0, 0] = ' ';
        }

    
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
