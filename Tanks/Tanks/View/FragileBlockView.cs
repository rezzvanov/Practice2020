using System.Drawing;
using Tanks.Model;

namespace Tanks.View
{
    class FragileBlockView : GameObjectView
    {
        private static FragileBlockView fragileBlock;

        public static FragileBlockView FragileBlock
        {
            get
            {
                return fragileBlock;
            }
        }

        static FragileBlockView()
        {
            fragileBlock = new FragileBlockView();
            fragileBlock.icon = Image.FromFile(@"Resources\FragileBlock.png");
        }

        public void Render(FragileBlock fragileBlock, Graphics graphics)
        {
            graphics.DrawImage(icon, fragileBlock.hitBox.Location);
        }
    }
}
