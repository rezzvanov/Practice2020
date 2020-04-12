using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Model;
using Tanks.View;
using System.Windows.Forms;

namespace Tanks.Controller
{
    class PackmanController
    {
        GameField gameField;
        GameFieldView gameFieldView;

        public PackmanController(GameField gameField, GameFieldView gameFieldView)
        {
            this.gameField = gameField;
            this.gameFieldView = gameFieldView;

            gameField.timer.Start();
        }

        private void handleInput(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:

                    break;
                case Keys.Left:
                case Keys.A:
                    gameField.Kolobok.Direction = Direction.Left;
                    break;
                case Keys.Up:
                case Keys.W:
                    gameField.Kolobok.Direction = Direction.Up;
                    break;
                case Keys.Right:
                case Keys.D:
                    gameField.Kolobok.Direction = Direction.Right;
                    break;
                case Keys.Down:
                case Keys.S:
                    gameField.Kolobok.Direction = Direction.Down;
                    break;
                default:
                    break;
            }
        }
    }
}
