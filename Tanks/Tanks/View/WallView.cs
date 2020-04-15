using System.Drawing;
using Tanks.Model;

namespace Tanks.View
{
    class WallView : GameObjectView
    {

        private static WallView wall;

        public static WallView Wall
        {
            get
            {
                wall = new WallView(); 
                wall.icon = Image.FromFile(@"Resources\Wall.png");
                return wall;
            }
        }

        public void Render(Wall wall, Graphics graphics)
        {
            graphics.DrawImage(icon, wall.hitBox.Location);
        }
    }
}
