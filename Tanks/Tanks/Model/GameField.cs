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
        private Size SizeCell = new Size(50, 50);
        private const int scale = 50;
        public int GameSpeed { get; }
        internal Kolobok Kolobok { get; set; }

        public Timer timer = new Timer();
        public int dt { get; }
        private Random rand = new Random();

        private readonly char[,] map = { { 'w', 'w', 'w', 'w', 'w', 'w' },
                                         { 'w', 'g', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'g', 'w' },
                                         { 'w', 'w', 'w', 'w', 'w', 'w' }};


        public List<Wall> walls = new List<Wall>();
        public List<Tank> tanks = new List<Tank>();
        public List<Apple> apples = new List<Apple>();

        public GameField(Size sizeField, int pace, int numbersOfTanks, int numbersOfApples)
        {
            SizeField = sizeField;
            SpawnField(numbersOfTanks, numbersOfApples);
            GameSpeed = 1000 / pace;
            timer.Interval = GameSpeed;
            dt = timer.Interval;

        }

        private void SpawnField(int numbersOfTanks, int numbersOfApples)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    switch (map[j, i])
                    {
                        case 'g':
                            continue;
                        case 'w':
                            walls.Add(new Wall(new Point(i * scale, j * scale), SizeCell));
                            break;
                        case 'k':
                            Kolobok = new Kolobok(new Point(i * scale, j * scale), SizeCell, Direction.Up);
                            break;
                        case 't':
                            SpawnTanks(numbersOfTanks, i, j);
                            break;
                    }
                }
            }
            SpawnApples(numbersOfApples);
        }

        private void SpawnTanks(int numbersOfTanks, int i, int j)
        {
            for (int k = 0; k < numbersOfTanks; k++)
            {
                tanks.Add(new Tank(new Point(i * scale, j * scale), SizeCell, (Direction)rand.Next(0, 4)));
            }
        }

        private void SpawnApples(int numbersOfApples)
        {
            for (int k = 0; k < numbersOfApples; k++)
            {
                int posX = rand.Next(0, SizeField.Width / scale);
                int posY = rand.Next(0, SizeField.Height / scale);

                if (map[posX, posY] == 'g')
                {
                    apples.Add(new Apple(new Point(posX * scale, posY * scale), SizeCell));
                }
                else
                {
                    k--;
                }
            }
        }

        private void UpdateKolobok()
        {
            Kolobok.continuousMove(dt);
        }

        private void UpdateTanks()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                int chanceOfTurning = rand.Next(0, 3);
                if (chanceOfTurning == 3)
                {
                    tanks[i].SelectTurn();
                }
                tanks[i].continuousMove(dt);
            }
        }

        private void RefreshApples()
        {
            if (apples.Count < 5)
            {
                SpawnApples(1);
            }
        }

        public void UpdateAllObject()
        {
            UpdateKolobok();
            UpdateTanks();
            RefreshApples();
        }

    }
}

