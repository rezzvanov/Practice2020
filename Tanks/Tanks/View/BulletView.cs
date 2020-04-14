using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tanks.Model;

namespace Tanks.View
{
    class BulletView : GameObjectView
    {
        private static BulletView bullet;

        public static BulletView Bullet
        {
            get
            {
                bullet = new BulletView();
                bullet.icon = Image.FromFile(@"Resources\Bullet.png");
                return bullet;
            }
        }
    }
}
