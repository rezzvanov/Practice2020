using System.Drawing;

namespace Tanks.Model
{
    public class Wall : GameObject
    {
        public Wall(Point initialPos, Size squareSize)
            : base(initialPos, squareSize)
        {
        }

        public override string Name
        {
            get
            {
                return "Wall";
            }
        }
    }
}
