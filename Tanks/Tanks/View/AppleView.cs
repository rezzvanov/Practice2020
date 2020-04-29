using System.Drawing;
using Tanks.Model;

namespace Tanks.View
{
    class AppleView : GameObjectView
    {
        private static AppleView apple;

        static AppleView()
        {
            apple = new AppleView();
            apple.icon = Image.FromFile(@"Resources\Apple.png");
        }

        public static AppleView Apple
        {
            get
            {
                return apple;
            }
        }

        public void Render(Apple apple, Graphics graphics)
        {
            graphics.DrawImage(icon, apple.hitBox.Location);
        }
    }
}
