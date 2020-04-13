using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Model;
using System.Drawing;

namespace Tanks.View
{
    abstract class GameObjectView
    {
        protected Image icon;

        public void Render(MovableObject movableObject, Graphics graphics)
        {
            graphics.DrawImage(icon, movableObject.hitBox.Location);
        }
    }
}
