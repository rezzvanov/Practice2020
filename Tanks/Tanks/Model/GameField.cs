using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tanks.Model
{
    public class GameField
    {
        public Size SizeField { get; }
        public int GameSpeed { get; }
        internal Kolobok Kolobok { get; set; }

        public Timer timer = new Timer();
        public int dt { get; }

        private readonly char[,] map = { };

        public GameField(Size sizeField, int pace)
        {
            SizeField = sizeField;
            dt = timer.Interval;

            SpawnField();

            GameSpeed = 1000 / pace;
        }

        private void SpawnField()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    switch (map[i, j])
                    {
                        case 'k':
                            Kolobok = new Kolobok(new Point(i, j), new Size(), Direction.Up);
                            break;
                    }
                }
            }
        }


        public void UpdateKolobok()
        {

        }

    }
}

