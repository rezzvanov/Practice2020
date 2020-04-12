using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks.Model
{
    enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    abstract class MovableObject : GameObject
    {
        public Direction Direction { get; set; }

        protected int speed;

        protected MovableObject(Point position, Size squareSize, Direction direction) : base(position, squareSize)
        {
            Direction = direction;
        }

        protected void Move(int dt)
        {
            switch (Direction)
            {
                case Direction.Down:
                    currenPos.Y -= speed * dt;
                    break;
                case Direction.Up:
                    currenPos.Y += speed * dt;
                    break;
                case Direction.Left:
                    currenPos.X -= speed * dt;
                    break;
                case Direction.Right:
                    currenPos.X += speed * dt;
                    break;
                default:
                    break;
            }
        }

    }
}
