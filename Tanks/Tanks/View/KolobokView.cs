using System;
using System.Drawing;

namespace Tanks.View
{
    class KolobokView : GameObjectView
    {
        private static KolobokView kolobok;

        public static KolobokView Kolobok
        {
            get
            {
                kolobok = new KolobokView();
                kolobok.icon = Image.FromFile(@"Resources\Kolobok.png");
                return kolobok;
            }
        }
    }
}
