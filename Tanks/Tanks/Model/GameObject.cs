using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Model
{
    using System.Drawing;

    abstract class GameObject
    {
        protected Point currenPos;
        protected Image icon;
        public Rectangle hitBox;

        protected GameObject(Point initialPos, Size squareSize)
        {
            currenPos = initialPos;
            hitBox = new Rectangle(initialPos, squareSize);
            
        }  
    }
}
