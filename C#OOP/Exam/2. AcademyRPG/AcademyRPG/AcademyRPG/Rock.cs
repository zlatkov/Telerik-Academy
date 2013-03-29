﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        public int Quantity
        {
            get { return this.HitPoints >> 1; }
        }

        public ResourceType Type
        {
            get { return ResourceType.Stone; }
        }

        public Rock(int hitPoints, Point position)
            : base(position)
        {
            this.HitPoints = hitPoints;
        }
    }
}
