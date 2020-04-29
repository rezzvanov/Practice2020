using System;
using System.Drawing;
using System.Windows.Forms;
using Tanks.Model;
using Tanks.View;

namespace Tanks
{
    delegate void FormInvoker();

    public partial class MainForm : Form
    {
        private GameField GameField { get; }
        private GameFieldView GameFieldView { get; }

        public Label Result
        {
            get
            {
                return resultL;
            }
        }

        public Label Score
        {
            get
            {
                return scoreL;
            }
        }

        public Button Button
        {
            get
            {
                return StartGameBut;
            }
        }

        public MainForm(GameField gameField, Size sizeField, GameFieldView gameFieldView)
        {
            InitializeComponent();

            GameField = gameField;
            GameFieldView = gameFieldView;
            pictureBox1.Size = gameField.SizeField;

            GameField.Timer.Tick += (s, e) => UpdateView();
        }

        public void UpdateView()
        {
            GameField.UpdateAllObject();
            Render();
        }

        private void Render()
        {
            Bitmap bitmap = new Bitmap(GameField.SizeField.Width, GameField.SizeField.Height);

            Graphics graphics = Graphics.FromImage(bitmap);

            KolobokView.Kolobok.Render(GameField.Kolobok, graphics);

            foreach (Wall wall in GameField.walls)
            {
                WallView.Wall.Render(wall, graphics);
            }

            foreach (Apple apple in GameField.apples)
            {
                AppleView.Apple.Render(apple, graphics);
            }

            foreach (Tank tank in GameField.tanks)
            {
                TankView.Tank.Render(tank, graphics);
            }

            foreach (River river in GameField.rivers)
            {
                RiverView.River.Render(river, graphics);
            }

            foreach (FragileBlock fragileBlock in GameField.fragileBlocks)
            {
                FragileBlockView.FragileBlock.Render(fragileBlock, graphics);
            }

            foreach (Bullet bullet in GameField.bullets)
            {
                BulletView.Bullet.Render(bullet, graphics);
            }

            foreach (Bullet bullet in GameField.enemyBullets)
            {
                BulletView.Bullet.Render(bullet, graphics);
            }

            FormInvoker fi = delegate
            {
                pictureBox1.Image = bitmap;
                pictureBox1.Invalidate();
            };
            Invoke(fi);
        }

        public void GameOver(object sender, EventArgs e)
        {
            Result.Text = "GameOver";
            Result.ForeColor = Color.Red;
            Result.Visible = true;
            Button.Enabled = true;
        }

        public void WonGame(object sender, EventArgs e)
        {
            Result.Text = "Win";
            Result.ForeColor = Color.Green;
            Result.Visible = true;
            Button.Enabled = true;
        }

        public void UpdateScore(object sender, EventArgs e)
        {
            Score.Text = $"Score: {GameField.Score}";
        }

        private void StartGameBut_Click(object sender, EventArgs e)
        {
            GameField.Reset();
            GameField.Timer.Start();
            StartGameBut.Enabled = false;
            resultL.Visible = false;
            Focus();
        }

    }
}
