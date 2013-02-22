using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.VersionAttribute
{
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct |
                    AttributeTargets.Interface |
                    AttributeTargets.Enum | 
                    AttributeTargets.Method)
    ]
    public class VersionAttribute : Attribute
    {
        private int minorVersion;
        private int majorVersion;

        public VersionAttribute(int majorVersion, int minorVersion)
        {
            this.minorVersion = minorVersion;
            this.majorVersion = majorVersion;
        }

        public string Version
        {
            get
            {
                return string.Format("{0}.{1}", this.majorVersion, this.minorVersion);
            }
        }
    }
}
