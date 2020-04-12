using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Model;
using System.Drawing;

namespace Tanks.View
{
    public class GameFieldView
    {
        public MainForm MainForm { get; }

        public GameFieldView(GameField gameField, Size sizeField)
        {
            MainForm = new MainForm(gameField, sizeField, this);
        }

    }
}
