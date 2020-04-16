using System.Drawing;

namespace Tanks.Model
{
    public class River : GameObject
    {
        public River(Point initialPos, Size squareSize)
            : base(initialPos, squareSize)
        {
        }

        public override string Name
        {
            get
            {
                return "River";
            }
        }
    }
}
