using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks.Model
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    public abstract class MovableObject : GameObject
    {
        public Direction Direction { get; set; }

        private const int offset = 1;

        protected MovableObject(Point position, Size squareSize, Direction direction) : base(position, squareSize)
        {
            Direction = direction;
        }

        protected void Move(int dt)
        {
            switch (Direction)
            {
                case Direction.Down:
                    currenPos.Y -= offset * dt;
                    break;
                case Direction.Up:
                    currenPos.Y += offset * dt;
                    break;
                case Direction.Left:
                    currenPos.X -= offset * dt;
                    break;
                case Direction.Right:
                    currenPos.X += offset * dt;
                    break;
                default:
                    break;
            }
            hitBox.Offset(new Point(currenPos.X, currenPos.Y));
        }

        public void continuousMove(int dt)
        {
            Move(dt);
        }
    }
}
