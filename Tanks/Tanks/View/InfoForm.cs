using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tanks.Model;

namespace Tanks.View
{
    public partial class InfoForm : Form
    {
        private GameField GameField { get; }

        public InfoForm(GameField gameField, GameFieldView gameFieldView)
        {
            InitializeComponent();

            GameField = gameField;
        }

        public void UpdateView(object sender, EventArgs e)
        {
            BindingList<GameObject> gameObjects = new BindingList<GameObject>(GameField.gameObjects);

            myDataGridView1.DataSource = GameField.gameObjects;
            myDataGridView1.Invalidate();
        }

    }
}
