using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints;

        public new int HitPoints
        {
            get
            {
                return 1;
            }
            set
            {
            }
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return 0; }
        }

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            base.HitPoints = 1;
            this.attackPoints = 0;   
        }


        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int targetIndex = -1;
            int maxTargetHitPoints = int.MinValue;

            for (int i = 0; i < availableTargets.Count; ++i)
            {
                if (availableTargets[i].Owner != 0 && availableTargets[i].Owner != this.Owner)
                {
                    if (availableTargets[i].HitPoints > maxTargetHitPoints)
                    {
                        maxTargetHitPoints = availableTargets[i].HitPoints;
                        targetIndex = i;
                    }
                }
            }

            return targetIndex;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += (resource.Quantity << 1);
                return true;
            }

            return false;
        }
    }
}
