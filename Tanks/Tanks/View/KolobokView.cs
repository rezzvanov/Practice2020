using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                kolobok.icon = Image.FromFile(@"Resources\Tank.png");
                return kolobok;
            }
        }
    }
}
