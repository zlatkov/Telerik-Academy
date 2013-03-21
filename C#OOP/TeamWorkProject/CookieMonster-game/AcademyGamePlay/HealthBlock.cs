using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Defines a health block in the game. The block increases the health of the player, who passes through the block.
    /// </summary>
    public class HealthBlock : StaticObject
    {
        public new const string CollisionGroupString = "healthBlock";
        public const int HealthBonus = 25;  //The bonus health which the block gives.

        public HealthBlock(GridPosition position)
            : base(position, '♥', ObjectColor.Red)
        {
        }

        public override string GetCollisionGroupString()
        {
            return HealthBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
