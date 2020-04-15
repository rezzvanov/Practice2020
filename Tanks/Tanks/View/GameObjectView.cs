using Tanks.Model;
using System.Drawing;

namespace Tanks.View
{
    abstract class GameObjectView
    {
        protected Image icon;

        private Direction currentDirection;

        public void Render(MovableObject movableObject, Graphics graphics)
        {
            Rotate(movableObject.Direction);

            graphics.DrawImage(icon, movableObject.hitBox.Location);
        }

        private void Rotate(Direction direction)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    switch (direction)
                    {
                        case Direction.Right:
                            icon.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case Direction.Left:
                            icon.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case Direction.Down:
                            icon.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        default:
                            break;
                    }
                    break;

                case Direction.Right:
                    switch (direction)
                    {
                        case Direction.Left:
                            icon.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case Direction.Up:
                            icon.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        case Direction.Down:
                            icon.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        default:
                            break;
                    }
                    break;

                case Direction.Left:
                    switch (direction)
                    {
                        case Direction.Left:
                            icon.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        case Direction.Right:
                            icon.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case Direction.Down:
                            icon.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        default:
                            break;
                    }
                    break;

                case Direction.Down:
                    switch (direction)
                    {
                        case Direction.Left:
                            icon.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case Direction.Right:
                            icon.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        case Direction.Up:
                            icon.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
            currentDirection = direction;
        }
    }


}
