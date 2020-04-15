using System;
using System.Windows.Forms;
using Tanks.Model;
using Tanks.View;
using Tanks.Controller;
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

            GameField gameField = new GameField(new Size(700, 700), 400, 5, 5);
            GameFieldView gameFieldView = new GameFieldView(gameField, gameField.SizeField);

            PackmanController packmanController = new PackmanController(gameField, gameFieldView);

            Application.Run(gameFieldView.MainForm);
        }
    }
}
