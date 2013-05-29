namespace RotatingWalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix
    {
        public const int EmptyCell = 0;
        public const int MaximumDimensionSize = 100;

        private int[,] matrix;
        private int nextCellValue;
        private Dictionary<Direction, Position> coordinatesOfDirection = new Dictionary<Direction, Position>();

        public Matrix(int dimension)
        {
            if (dimension <= 0 || dimension > Matrix.MaximumDimensionSize)
            {
                throw new ArgumentOutOfRangeException("The dimension must between 0 and " + Matrix.MaximumDimensionSize);
            }

            this.matrix = new int[dimension, dimension];
            this.Dimension = dimension;
            this.nextCellValue = 1;

            this.coordinatesOfDirection[Direction.East] = new Position(0, 1);
            this.coordinatesOfDirection[Direction.SouthEast] = new Position(1, 1);
            this.coordinatesOfDirection[Direction.South] = new Position(1, 0);
            this.coordinatesOfDirection[Direction.SouthWest] = new Position(1, -1);
            this.coordinatesOfDirection[Direction.West] = new Position(0, -1);
            this.coordinatesOfDirection[Direction.NorthWest] = new Position(-1, -1);
            this.coordinatesOfDirection[Direction.North] = new Position(-1, 0);
            this.coordinatesOfDirection[Direction.NorthEast] = new Position(-1, 1);
        }

        public int Dimension { get; private set; }

        public void Traverse()
        {
           Position currentPosition;
           bool matrixHasEmptyCell = this.TryFindEmptyCell(out currentPosition);
           if (matrixHasEmptyCell)
           {
               Direction currentDirection = Direction.SouthEast;

               this.VisitCell(currentPosition);
               while (this.HasEmptyNeighbour(currentPosition))
               {
                   currentDirection = this.GetFirstClockwiseEmptyCell(currentPosition, currentDirection);
                   currentPosition = this.GetNeighborCell(currentPosition, currentDirection);

                   this.VisitCell(currentPosition);
               }

               this.Traverse();
           }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Dimension; ++i)
            {
                if (i > 0)
                {
                    result.Append("\n");
                }

                for (int j = 0; j < this.Dimension; ++j)
                {
                    if (j > 0)
                    {
                        result.Append(" ");
                    }

                    result.Append(this.matrix[i, j]);
                }
            }

            return result.ToString();
        }

        private Direction GetClockwiseRotatedDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    {
                        return Direction.SouthEast;
                    }

                case Direction.SouthEast:
                    {
                        return Direction.South;
                    }

                case Direction.South:
                    {
                        return Direction.SouthWest;
                    }

                case Direction.SouthWest:
                    {
                        return Direction.West;
                    }

                case Direction.West:
                    {
                        return Direction.NorthWest;
                    }

                case Direction.NorthWest:
                    {
                        return Direction.North;
                    }

                case Direction.North:
                    {
                        return Direction.NorthEast;
                    }

                case Direction.NorthEast:
                    {
                        return Direction.East;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException("Invalid direction.");
                    }
            }
        }

        private Position GetNeighborCell(Position position, Direction direction)
        {
            Position neighbor = new Position();
            Position directionCoordinates = this.coordinatesOfDirection[direction];
            neighbor.Row = position.Row + directionCoordinates.Row;
            neighbor.Column = position.Column + directionCoordinates.Column;

            return neighbor;
        }

        private bool TryFindEmptyCell(out Position emptyCell)
        {
            emptyCell = new Position(0, 0);
            for (int i = 0; i < this.Dimension; ++i)
            {
                for (int j = 0; j < this.Dimension; ++j)
                {
                    if (this.matrix[i, j] == Matrix.EmptyCell)
                    {
                        emptyCell.Row = i;
                        emptyCell.Column = j;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsEmptyCell(Position position)
        {
            return this.matrix[position.Row, position.Column] == Matrix.EmptyCell;
        }

        private bool HasEmptyNeighbour(Position position)
        {
            foreach (var direction in this.coordinatesOfDirection)
            {
                Position neighbor = this.GetNeighborCell(position, direction.Key);
                if (this.IsInsideBoundaries(neighbor) && this.IsEmptyCell(neighbor))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsInsideBoundaries(Position position)
        {
            return position.Row < this.Dimension
                && position.Column < this.Dimension
                && position.Row >= 0
                && position.Column >= 0;
        }

        private Direction GetFirstClockwiseEmptyCell(Position position, Direction direction)
        {
            Position neighbor = this.GetNeighborCell(position, direction);
            Direction neighborDirection = direction;
            while (!this.IsInsideBoundaries(neighbor) || !this.IsEmptyCell(neighbor))
            {
                neighborDirection = this.GetClockwiseRotatedDirection(neighborDirection);
                neighbor = this.GetNeighborCell(position, neighborDirection);
            }

            return neighborDirection;
        }

        private void VisitCell(Position position)
        {
            this.matrix[position.Row, position.Column] = this.nextCellValue;
            this.nextCellValue++;
        }
    }
}
