using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Model
{
    using System.Drawing;

    public abstract class GameObject
    {
        public Point currenPos;
        public Rectangle hitBox;

        protected GameObject(Point initialPos, Size squareSize)
        {
            currenPos = initialPos;
            hitBox = new Rectangle(initialPos, squareSize);
            
        }  
    }
}
