using System.Drawing;

namespace Tanks.View
{
    class TankView : GameObjectView
    {
        private static TankView tank;

        public static TankView Tank
        {
            get
            {
                tank = new TankView();
                tank.icon = Image.FromFile(@"Resources\Tank.png");
                return tank;
            }
        }
    }
}
