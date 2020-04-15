namespace Tanks.Model
{
    using System.Drawing;

    public abstract class GameObject
    {
        public Point currenPos;
        public Rectangle hitBox;

        protected GameObject(Point initialPos, Size squareSize)
        {
            currenPos = initialPos;
            hitBox = new Rectangle(initialPos, squareSize);        
        }

        public virtual string Name
        {
            get
            {
                return "GameObject";
            }
        }

        public int X
        {
            get
            {
                return hitBox.X;
            }
        }

        public int Y
        {
            get
            {
                return hitBox.Y;
            }
        }
    }
}
