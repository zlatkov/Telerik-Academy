using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Provides a static method for generating block with specific characteristics.
    /// </summary>
    public static class BlockFactory
    {
        private static Random rand = new Random();

        /// <summary>
        /// Returns a block created from the specified type, position and color.
        /// </summary>
        public static StaticObject CreateBlock(int blockType, GridPosition position, ObjectColor color)
        {
            switch (blockType)
            {
                case 0: return new Wall(position, color);
                case 1: return new GiftBlock(position, color, rand.Next(0, 10));
                case 2: return new HealthBlock(position);  //The health block is always red.
                case 3: return new Obstacle(position, color);
                default: return new Obstacle(position, color);
            }
        }
    }
}
