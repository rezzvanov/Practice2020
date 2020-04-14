using System.Drawing;

namespace Tanks.Model
{
    class Kolobok : MovableObject
    {
        public Kolobok(Point initialPos, Size squareSize, Direction direction) 
            : base(initialPos, squareSize, direction)
        {
        }
    }
}
