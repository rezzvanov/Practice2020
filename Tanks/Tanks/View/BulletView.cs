using System.Drawing;

namespace Tanks.View
{
    class BulletView : GameObjectView
    {
        private static BulletView bullet;

        public static BulletView Bullet
        {
            get
            {
                return bullet;
            }
        }

        static BulletView()
        {
            bullet = new BulletView();
            bullet.icon = Image.FromFile(@"Resources\Bullet.png");
        }
    }
}
