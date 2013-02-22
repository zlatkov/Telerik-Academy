using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingRocks
{
    public interface GameObject
    {
        int X
        {
            get;
        }

        int Y
        {
            get;
        }

        ConsoleColor Color
        {
            get;
        }

        void Draw();
    }
}
