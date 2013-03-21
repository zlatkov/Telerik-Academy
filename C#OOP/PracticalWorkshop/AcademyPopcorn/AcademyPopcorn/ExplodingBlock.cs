using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = '@';
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<ExplodingWave> objectsAround = new List<ExplodingWave>()
                {
                    new ExplodingWave(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col - 1)), //to the left
                    new ExplodingWave(new MatrixCoords(this.TopLeft.Row - 1, this.TopLeft.Col)), //to the top
                    new ExplodingWave(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col + 1)), //to the right
                    new ExplodingWave(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col))  //to the bottom
                };

                return objectsAround;
            }
            return new List<GameObject>();
        }

    }
}
