using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Defines a gift block in the game. The block drops a score bonus from 0 to 9 points when destroyed.
    /// </summary>
    public class GiftBlock : StaticObject
    {
        public new const string CollisionGroupString = "giftBlock";

        public EventHandler<GameOverEventArgs> onGameOver;

        public GiftBlock(GridPosition position, ObjectColor color, int bonus)
            : base(position, '$', color)
        {
            if (bonus < 0 || bonus > 9)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.Bonus = bonus;
            }
        }

        /// <summary>
        /// Gets the bonus score which the blocks will drop.
        /// </summary>
        public int Bonus { protected set; get; }

        public override string GetCollisionGroupString()
        {
            return GiftBlock.CollisionGroupString;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                return new List<ScoreBlock>()
                {
                    new ScoreBlock(this.GetObjectPosition(), this.GetObjectColor(), this.Bonus)
                };
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}
