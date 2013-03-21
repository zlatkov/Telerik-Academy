using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        private int bulletsLeft;
        private bool shouldShoot;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.bulletsLeft = 0;
            this.shouldShoot = false;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.shouldShoot && this.bulletsLeft > 0)
            {
                this.shouldShoot = false;
                this.bulletsLeft--;
                return new List<Bullet>() 
                { 
                    new Bullet(new MatrixCoords(this.topLeft.Row, (2 * this.topLeft.Col + this.Width) >> 1)) 
                };
            }
            return new List<GameObject>();
        }

        public void Shoot()
        {
            if (this.bulletsLeft > 0)
            {
                this.shouldShoot = true;
            }
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (string collisionObject in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (collisionObject == "gift")
                {
                    this.bulletsLeft += Gift.BulletsBonus;
                }
            }
        }
    }
}
