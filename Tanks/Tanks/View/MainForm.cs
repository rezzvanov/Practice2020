using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.Model;
using Tanks.Controller;
using Tanks.View;

namespace Tanks
{
    delegate void FormInvoker();

    public partial class MainForm : Form
    {
        private GameField GameField { get; }
        private GameFieldView GameFieldView { get; }

        public MainForm(GameField gameField, Size sizeField, GameFieldView gameFieldView)
        {
            InitializeComponent();

            GameField = gameField;
            GameFieldView = gameFieldView;

            GameField.timer.Tick += (s, e) => UpdateView();
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

            FormInvoker fi = delegate
            {
                pictureBox1.Image = bitmap;
                pictureBox1.Invalidate();
            };
            Invoke(fi);
        }
    }
}
