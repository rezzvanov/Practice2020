using System.Drawing;
using Tanks.Model;

namespace Tanks.View
{
    class RiverView : GameObjectView
    {
        private static RiverView river;

        public static RiverView River
        {
            get
            {
                river = new RiverView();
                river.icon = Image.FromFile(@"Resources\River.png");
                return river;
            }
        }

        public void Render(River river, Graphics graphics)
        {
            graphics.DrawImage(icon, river.hitBox.Location);
        }
    }
}
