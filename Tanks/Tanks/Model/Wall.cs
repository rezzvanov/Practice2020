using System.Drawing;

namespace Tanks.Model
{
    class Wall : GameObject
    {
        public Wall(Point initialPos, Size squareSize)
            : base(initialPos, squareSize)
        {
        }
    }
}
