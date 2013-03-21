using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Describes a score block in the game. The score block is produced by the gift block.
    /// The image which is given to the score block is the amount of score bonus it gives.
    /// </summary>
    public class ScoreBlock : StaticObject
    {
        public new const string CollisionGroupString = "scoreBlock";

        public ScoreBlock(GridPosition position, ObjectColor color, int bonus)
            : base(position, (char)(bonus + '0'), color)
        {
        }

        public override string GetCollisionGroupString()
        {
            return ScoreBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
