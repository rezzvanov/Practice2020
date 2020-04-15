using Tanks.Model;
using System.Drawing;

namespace Tanks.View
{
    public class GameFieldView
    {
        public MainForm MainForm { get; }

        public InfoForm InfoForm { get; }

        public GameFieldView(GameField gameField, Size sizeField)
        {
            MainForm = new MainForm(gameField, sizeField, this);
            InfoForm = new InfoForm(gameField, this);
            InfoForm.Show();
        }       
    }
}
