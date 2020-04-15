using System.Drawing;

namespace Tanks.Model
{
    public class Apple : GameObject
    {
        public Apple(Point initialPos, Size squareSize)
            : base(initialPos, squareSize)
        {
        }

        public override string Name
        {
            get
            {
                return "Apple";
            }
        }
    }
}
