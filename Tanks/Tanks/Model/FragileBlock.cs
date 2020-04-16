using System.Drawing;

namespace Tanks.Model
{
    public class FragileBlock : GameObject
    {
        public FragileBlock(Point initialPos, Size squareSize)
            : base(initialPos, squareSize)
        {
        }

        public override string Name
        {
            get
            {
                return "FragileBlock";
            }
        }
    }
}
