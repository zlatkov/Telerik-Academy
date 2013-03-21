using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// The position of every object in the game is represented with GridPosition.
    /// </summary>
    public class GridPosition
    {
        public GridPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Sums the coordinates for two objects in the game.
        /// </summary>
        /// <param name="a">The position of the first object</param>
        /// <param name="b">The position of the second object</param>
        public static GridPosition operator +(GridPosition a, GridPosition b)
        {
            return new GridPosition(a.X + b.X, a.Y + b.Y);
        }

        public static bool operator ==(GridPosition a, GridPosition b)
        {
            return GridPosition.Equals(a, b);
        }

        public static bool operator !=(GridPosition a, GridPosition b)
        {
            return !GridPosition.Equals(a, b);
        }

        /// <summary>
        /// Determines if two GridPositions are equal.
        /// </summary>
        public override bool Equals(object obj)
        {
            GridPosition objPosition = obj as GridPosition;
            if (objPosition == null)
            {
                return false;
            }
            else
            {
                //GridPositions are equal if their both coordinates are equal.
                return this.X == objPosition.X && this.Y == objPosition.Y;
            }
        }

        /// <summary>
        /// Gets the hash code of the GridPosition.
        /// It concatenates the first 16 bits of the X coordinate and concatenates it 
        /// with the first 16 bits of the Y coordinate.
        /// </summary>
        /// <returns>The calculated hash code.</returns>
        public override int GetHashCode()
        {
            return (this.X.GetHashCode() << 16) | (this.Y.GetHashCode() & 0xffff);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.X, this.Y);
        }
    }
}
