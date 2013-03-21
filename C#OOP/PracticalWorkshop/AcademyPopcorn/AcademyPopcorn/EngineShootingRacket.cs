using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class EngineShootingRacket : Engine
    {
        ShootingRacket racket;
        public EngineShootingRacket(IRenderer renderer, IUserInterface userInterface) 
            : base (renderer, userInterface)
        {
        }

        public EngineShootingRacket(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : base(renderer, userInterface, sleepTime)
        {
        }

        public void ShootPlayerRacket()
        {
            racket = this.playerRacket as ShootingRacket;
            racket.Shoot();
        }
    }
}
