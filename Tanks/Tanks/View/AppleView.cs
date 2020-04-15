using System.Drawing;
using Tanks.Model;

namespace Tanks.View
{
    class AppleView : GameObjectView
    {
        private static AppleView apple;

        public static AppleView Apple
        {
            get 
            {
                apple = new AppleView();
                apple.icon = Image.FromFile(@"Resources\Apple.png");
                return apple;
            }
        }

        public void Render(Apple apple, Graphics graphics)
        {
            graphics.DrawImage(icon, apple.hitBox.Location);
        }
    }
}
