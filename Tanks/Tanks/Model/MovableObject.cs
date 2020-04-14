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

        protected int offset = 1;

        public int lastPosX;
        public int lastPosY;

        protected MovableObject(Point position, Size squareSize, Direction direction) : base(position, squareSize)
        {
            Direction = direction;
        }

        protected void Move(int dt)
        {
            lastPosX = hitBox.X;
            lastPosY = hitBox.Y;

            switch (Direction)
            {
                case Direction.Down:
                    currenPos = new Point(0, offset * dt);
                    break;
                case Direction.Up:
                    currenPos = new Point(0, -offset * dt);
                    break;
                case Direction.Left:
                    currenPos = new Point(-offset * dt, 0);
                    break;
                case Direction.Right:
                    currenPos = new Point(offset * dt, 0);
                    break;
                default:
                    break;
            }
            hitBox.Offset(currenPos);
        }

        public void continuousMove(int dt)
        {
            Move(dt);
        }
}
}
