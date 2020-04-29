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
                return wall;
            }
        }

        static WallView()
        {
            wall = new WallView();
            wall.icon = Image.FromFile(@"Resources\Wall.png");
        }

        public void Render(Wall wall, Graphics graphics)
        {
            graphics.DrawImage(icon, wall.hitBox.Location);
        }
    }
}
