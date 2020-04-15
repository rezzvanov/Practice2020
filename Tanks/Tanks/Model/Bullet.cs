using System.Drawing;

namespace Tanks.Model
{
    public class Bullet : MovableObject
    {
        public Bullet(MovableObject shooter, Size squareSize) 
            : base(new Point(shooter.hitBox.X + shooter.hitBox.Width / 2, shooter.hitBox.Y + shooter.hitBox.Width / 2), squareSize, shooter.Direction)
        {
            offset = 3;
        }

        public override string Name
        {
            get
            {
                return "Bullet";
            }
        }
    }
}
