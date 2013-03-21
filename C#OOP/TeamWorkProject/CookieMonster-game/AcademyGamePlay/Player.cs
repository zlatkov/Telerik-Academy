using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Represents an abstract player class which must be inherited from either a human player or an AI player.
    /// </summary>
    public abstract class Player : MovingObject
    {
        protected bool shouldShoot;   //Determines if the player should shoot.
        protected GridPosition lastMoveDirection; //The direction in which the player last moved.

        public new const string CollisionGroupString = "player";
        public const int PlayerMaxHealth = 100;  //The maximal health a player can have.
   
        //The initial direction of each player is down.
        protected Player(string name, GridPosition position, ObjectColor color)
            : base(position, 'V', color)
        {
            this.Name = name;
            this.Score = 0;
            this.Health = Player.PlayerMaxHealth;

            this.shouldShoot = false;
            this.lastMoveDirection = new GridPosition(1, 0);
        }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { protected set; get; }

        /// <summary>
        /// Gets the score of the player.
        /// </summary>
        public int Score { protected set; get; }

        /// <summary>
        /// Gets the health of the player.
        /// </summary>
        public int Health { protected set; get; }

        /// <summary>
        /// Tells the player to make a move.
        /// </summary>
        public abstract void MakeMove();

        /// <summary>
        /// Tells the player to move left
        /// </summary>
        protected virtual void OnMoveLeft(object sender, EventArgs args)
        {
            this.Direction = new GridPosition(0, -1);
            this.lastMoveDirection = this.Direction;

            if (this.image != '<')
            {
                this.image = '<'; 
            }
            
        }

        /// <summary>
        /// Tells the player to move right.
        /// </summary>
        protected virtual void OnMoveRight(object sender, EventArgs args)
        {
            this.Direction = new GridPosition(0, 1);
            this.lastMoveDirection = this.Direction;

            if (this.image != '>')
            {
                this.image = '>';    
            }
        }

        /// <summary>
        /// Tells the player to move up.
        /// </summary>
        protected virtual void OnMoveUp(object sender, EventArgs args)
        {
            this.Direction = new GridPosition(-1, 0);
            this.lastMoveDirection = this.Direction;

            if (this.image != '^')
            {
                this.image = '^';
            }
        }

        /// <summary>
        /// Tells the player to move down.
        /// </summary>
        protected virtual void OnMoveDown(object sender, EventArgs args)
        {
            this.Direction = new GridPosition(1, 0);
            this.lastMoveDirection = this.Direction;

            if (this.image != 'v')
            {
                this.image = 'v';
            }
        }

        /// <summary>
        /// Tells the player to shoot.
        /// </summary>
        protected virtual void OnShoot(object sender, EventArgs args)
        {
            this.shouldShoot = true;
        }

        public override string GetCollisionGroupString()
        {
            return Player.CollisionGroupString;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            //If the player should shoot, a new bullet is produced.
            //The direction of the bullet is the same as the last direction of the player.
            //The color of the bullet is the same as the player who shoots it.
            if (this.shouldShoot)
            {
                this.shouldShoot = false;
                return new List<Bullet>() 
                { 
                    new Bullet(this.Position + this.lastMoveDirection, this.GetObjectColor(), this.lastMoveDirection) 
                };
            }
            else
            {
                return new List<GameObject>();
            }
            
        }

        public override void Update()
        {
            this.Position += this.Direction;
            this.Direction = new GridPosition(0, 0);
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "gameObject"
                || otherCollisionGroupString == "wall" 
                || otherCollisionGroupString == "giftBlock"
                || otherCollisionGroupString == "scoreBlock"
                || otherCollisionGroupString == "healthBlock" 
                || otherCollisionGroupString == "player";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //If there is a collision the player must stop moving.
            this.Direction = new GridPosition(0, 0);

            //If the player is hit by a bullet
            if (collisionData.ObjectCollisionGroupString == "bullet")
            {
                //If the player has more health than the damage which the bullet does.
                if (this.Health > Bullet.Damage)
                {
                    this.Health -= Bullet.Damage;
                }
                    //Otherwise the player dies.
                else
                {
                    this.IsDestroyed = true;
                }
            }
                //If the player hits a score block, the score bonus is added to the player's score.
            else if (collisionData.ObjectCollisionGroupString == "scoreBlock")
            {
                this.Score += (int)(collisionData.ObjectImage - '0');
            }
                //If the player hits a health block, the health bonus is added to the player's health.
                //The current health of the player + the health bonus must not exceed the maximum health a player can have.
            else if (collisionData.ObjectCollisionGroupString == "healthBlock")
            {
                this.Health = Math.Min(Player.PlayerMaxHealth, this.Health + HealthBlock.HealthBonus);
            }
        }
    }
}
