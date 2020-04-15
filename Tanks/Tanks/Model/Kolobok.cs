using System.Drawing;

namespace Tanks.Model
{
    public class Kolobok : MovableObject
    {
        public Kolobok(Point initialPos, Size squareSize, Direction direction) 
            : base(initialPos, squareSize, direction)
        {
        }

        public override string Name
        {
            get
            {
                return "Kolobok";
            }
        }
    }
}
