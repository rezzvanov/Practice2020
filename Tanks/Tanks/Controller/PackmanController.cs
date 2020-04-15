using System;
using Tanks.Model;
using Tanks.View;
using System.Windows.Forms;
using System.Drawing;

namespace Tanks.Controller
{
    class PackmanController
    {
        GameField gameField;
        GameFieldView gameFieldView;
        DateTime lastFire;

        public PackmanController(GameField gameField, GameFieldView gameFieldView)
        {
            this.gameField = gameField;
            this.gameFieldView = gameFieldView;

            gameField.ScoreUpdate += UpdateScore;
            gameField.End += GameOver;
            gameField.Win += WonGame;
            gameFieldView.MainForm.KeyDown += handleInput;
        }

        private void handleInput(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if ((DateTime.Now - lastFire).TotalMilliseconds > 800)
                    {
                        gameField.Shoot(gameField.Kolobok);
                        lastFire = DateTime.Now;
                    }
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

        private void GameOver(object sender, EventArgs e)
        {
            gameField.timer.Stop();
            gameFieldView.MainForm.Result.Text = "GameOver";
            gameFieldView.MainForm.Result.ForeColor = Color.Red;
            gameFieldView.MainForm.Result.Visible = true;
            gameFieldView.MainForm.Button.Enabled = true;
        }

        private void WonGame(object sender, EventArgs e)
        {
            gameField.timer.Stop();
            gameFieldView.MainForm.Result.Text = "Win";
            gameFieldView.MainForm.Result.ForeColor = Color.Green;
            gameFieldView.MainForm.Result.Visible = true;
            gameFieldView.MainForm.Button.Enabled = true;
        }

        private void UpdateScore(object sender, EventArgs e)
        {
            gameFieldView.MainForm.Score.Text = $"Score: {gameField.Score}";
        }
    }
}
