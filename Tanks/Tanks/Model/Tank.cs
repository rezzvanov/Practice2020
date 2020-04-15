using System;
using System.Drawing;

namespace Tanks.Model
{
    public class Tank : MovableObject
    {
        public Tank(Point initialPos, Size squareSize, Direction direction) 
            : base(initialPos, squareSize, direction)
        {
        }

        private Random rand = new Random();

        public void SelectTurn()
        {
            Direction = (Direction)rand.Next(0, 4);
        }

        public void Turn()
        {
            switch (Direction)
            {
                case Direction.Down:
                    Direction = Direction.Up;
                    break;
                case Direction.Up:
                    Direction = Direction.Down;
                    break;
                case Direction.Left:
                    Direction = Direction.Right;
                    break;
                case Direction.Right:
                    Direction = Direction.Left;
                    break;
                default:
                    break;
            }
        }
        public override string Name
        {
            get
            {
                return "Tank";
            }
        }
    }
}
