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
    public partial class MainForm : Form
    {
        private GameField GameField { get; }
        private GameField GameFieldView { get; }

        public MainForm(GameField gameField, Size sizeField, GameFieldView gameFieldView)
        {
            pictureBox1.Size = sizeField;

            InitializeComponent();            
        }

        private void Render()
        {
            Bitmap bitmap = new Bitmap(GameField.SizeField.Width, GameField.SizeField.Height);

            Graphics graphics = Graphics.FromImage(bitmap);
        }
    }
}
