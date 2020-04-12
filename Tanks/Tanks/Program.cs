using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.Model;
using Tanks.View;
using System.Drawing;

namespace Tanks
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameField gameField = new GameField(new Size(500, 500), 60);
            GameFieldView gameFieldView = new GameFieldView(gameField, gameField.SizeField);

            Application.Run(new MainForm());
        }
    }
}
