namespace RotatingWalk
{
    using System;
    using System.Linq;

    public class Position
    {
        public Position(int row = 0, int column = 0)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.Row, this.Column);
        }
    }
}
