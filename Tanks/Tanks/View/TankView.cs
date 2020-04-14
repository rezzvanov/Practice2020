using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tanks.Model;

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
