using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Holds some data when a collision occurs.
    /// </summary>
    public struct CollisionData
    {
        private char objectImage;
        private string objectCollisionGroupString;

        public CollisionData(char objectImage, string objectCollisionGroupString)
        {
            this.objectImage = objectImage;
            this.objectCollisionGroupString = objectCollisionGroupString;
        }

        public char ObjectImage 
        {
            get
            {
                return this.objectImage;
            }
        }
        public string ObjectCollisionGroupString 
        {
            get
            {
                return this.objectCollisionGroupString;
            }
        }
    }
}
