﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tanks.Model
{
    public class GameField
    {
        public Size SizeField { get; }
        private Size SizeCell = new Size(50, 50);
        private Size SizeBullet = new Size(9, 12);
        private const int scale = 50;
        public Timer timer = new Timer();
        public int GameSpeed { get; }
        public Kolobok Kolobok { get; set; }
        public int dt { get; }

        public event EventHandler ScoreUpdate;
        public event EventHandler Win;
        public event EventHandler End;


        public int Score { get; private set; } = 0;

        private Random rand = new Random();

        private readonly char[,] map = { { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
                                         { 'w', 'g', 't', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 't', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 't', 'g', 'g', 'g', 't', 'g', 'g', 'g', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'g', 'w', 'g', 't', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'g', 'w', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'g', 'g', 'k', 'g', 'g', 'g', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'w' },
                                         { 'w', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'g', 'w' },
                                         { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' }};


        public List<Wall> walls = new List<Wall>();
        public List<Tank> tanks = new List<Tank>();
        public List<Apple> apples = new List<Apple>();
        public List<Bullet> enemyBullets = new List<Bullet>();
        public List<Bullet> bullets = new List<Bullet>();
        public List<GameObject> gameObjects = new List<GameObject>();

        public GameField(Size sizeField, int pace, int numbersOfTanks, int numbersOfApples)
        {
            SizeField = sizeField;
            SpawnFieldObjectsOnfield(numbersOfTanks, numbersOfApples);
            GameSpeed = 1000 / pace;
            timer.Interval = GameSpeed;
            dt = timer.Interval;

        }

        private void SpawnFieldObjectsOnfield(int numbersOfTanks, int numbersOfApples)
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
            tanks.Add(new Tank(new Point(i * scale, j * scale), SizeCell, (Direction)rand.Next(0, 4)));
        }

        private void SpawnApples(int numbersOfApples)
        {
            for (int k = 0; k < numbersOfApples; k++)
            {
                int posX = rand.Next(0, SizeField.Width / scale);
                int posY = rand.Next(0, SizeField.Height / scale);

                if (map[posY, posX] == 'g')
                {
                    apples.Add(new Apple(new Point(posX * scale, posY * scale), SizeCell));
                }
                else
                {
                    k--;
                }
            }
        }

        public void Shoot(MovableObject movObject)
        {
            bullets.Add(new Bullet(movObject, SizeBullet));
        }

        public void ShotEnemy(MovableObject movObject)
        {
            enemyBullets.Add(new Bullet(movObject, SizeBullet));
        }


        private void UpdateKolobok()
        {
            Kolobok.continuousMove(dt);

            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i].hitBox.IntersectsWith(Kolobok.hitBox))
                {
                    if (Kolobok.Direction == Direction.Up || Kolobok.Direction == Direction.Left)
                    {
                        Kolobok.hitBox.Offset(new Point(Math.Abs(Kolobok.lastPosX - Kolobok.hitBox.X), Math.Abs(Kolobok.lastPosY - Kolobok.hitBox.Y)));
                    }
                    if (Kolobok.Direction == Direction.Down || Kolobok.Direction == Direction.Right)
                    {
                        Kolobok.hitBox.Offset(new Point(Kolobok.lastPosX - Kolobok.hitBox.X, Kolobok.lastPosY - Kolobok.hitBox.Y));
                    }
                }
            }

            for (int i = 0; i < apples.Count; i++)
            {
                if (apples[i].hitBox.IntersectsWith(Kolobok.hitBox))
                {
                    Score++;
                    Updatescore();
                    apples.RemoveAt(i);
                }
            }

            for (int i = 0; i < enemyBullets.Count; i++)
            {
                if (enemyBullets[i].hitBox.IntersectsWith(Kolobok.hitBox))
                {
                    GameOver();
                }
            }
        }

        private void UpdateTanks()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                int chanceOfTurning = rand.Next(0, 100);

                for (int j = 0; j < walls.Count; j++)
                {
                    if (chanceOfTurning == 99)
                    {
                        tanks[i].SelectTurn();
                    }
                    if (walls[j].hitBox.IntersectsWith(tanks[i].hitBox))
                    {
                        tanks[i].Turn();
                        tanks[i].continuousMove(dt);
                    }
                }
                tanks[i].continuousMove(dt);

                for (int z = 0; z < tanks.Count; z++)
                {
                    if (tanks[i].hitBox.IntersectsWith(tanks[z].hitBox))
                    {
                        tanks[i].Turn();
                        tanks[z].Turn();

                        break;
                    }
                }

                int chanceOfShot = rand.Next(0, 51);
                if (chanceOfShot == 50)
                {
                    ShotEnemy(tanks[i]);
                }

                if (tanks[i].hitBox.IntersectsWith(Kolobok.hitBox))
                {
                    GameOver();
                }
            }

            if(tanks.Count == 0)
            {
                GameWon();
            }
        }

        private void RefreshApples()
        {
            if (apples.Count < 5)
            {
                SpawnApples(1);
            }
        }

        private void UpdateBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].continuousMove(dt);

                for (int j = 0; j < walls.Count; j++)
                {
                    if (bullets[i].hitBox.IntersectsWith(walls[j].hitBox))
                    {
                        bullets.RemoveAt(i);
                        break;
                    }
                }
            }

            for (int i = 0; i < enemyBullets.Count; i++)
            {
                enemyBullets[i].continuousMove(dt);

                for (int j = 0; j < walls.Count; j++)
                {
                    if (enemyBullets[i].hitBox.IntersectsWith(walls[j].hitBox))
                    {
                        enemyBullets.RemoveAt(i);
                        break;
                    }
                }
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; j < tanks.Count; j++)
                {
                    if (bullets[i].hitBox.IntersectsWith(tanks[j].hitBox))
                    {
                        tanks.RemoveAt(j);
                        bullets.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void Updatescore()
        {
            ScoreUpdate?.Invoke(this, EventArgs.Empty);
        }

        private void GameOver()
        {
            End?.Invoke(this, EventArgs.Empty);
        }

        private void GameWon()
        {
            Win?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateAllObject()
        {
            UpdateKolobok();
            UpdateTanks();
            RefreshApples();
            UpdateBullets();
            UpdateObjectData();
        }

        public void Reset()
        {
            walls = new List<Wall>();
            tanks = new List<Tank>();
            apples = new List<Apple>();
            enemyBullets = new List<Bullet>();
            bullets = new List<Bullet>();
            Score = 0;
            Updatescore();
            SpawnFieldObjectsOnfield(5, 5);
        }

        private void UpdateObjectData()
        {
            gameObjects = new List<GameObject>();
            gameObjects.Add(Kolobok);
            gameObjects.AddRange(tanks);
            gameObjects.AddRange(apples);
            gameObjects.AddRange(enemyBullets);
            gameObjects.AddRange(bullets);
        }
    }
}

