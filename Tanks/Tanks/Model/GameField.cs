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
        private Size SizeBullet = new Size(9, 12);
        private const int scale = 50;
        public Timer Timer { get; } = new Timer();
        public int GameSpeed { get; }
        public Kolobok Kolobok { get; set; }
        public int dt { get; }

        public event EventHandler ScoreUpdate;
        public event EventHandler Win;
        public event EventHandler End;


        public static int Score { get; private set; } = 0;

        private Random rand = new Random();

        private string[] map;


        public List<Wall> walls = new List<Wall>();
        public List<Tank> tanks = new List<Tank>();
        public List<Apple> apples = new List<Apple>();
        public List<Bullet> enemyBullets = new List<Bullet>();
        public List<Bullet> bullets = new List<Bullet>();
        public List<River> rivers = new List<River>();
        public List<FragileBlock> fragileBlocks = new List<FragileBlock>();
        public List<GameObject> gameObjects = new List<GameObject>();

        public GameField(Size sizeField, int pace, int numbersOfTanks, int numbersOfApples)
        {
            SizeField = sizeField;
            SpawnObjectsOnField(numbersOfTanks, numbersOfApples);
            GameSpeed = 1000 / pace;
            Timer.Interval = GameSpeed;
            dt = Timer.Interval;
        }

        private void SpawnObjectsOnField(int numbersOfTanks, int numbersOfApples)
        {
            ReadTextFile();

            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    switch (map[j][i])
                    {
                        case 'g':
                            continue;
                        case 'w':
                            walls.Add(new Wall(new Point(i * scale, j * scale), SizeCell));
                            break;
                        case 'r':
                            rivers.Add(new River(new Point(i * scale, j * scale), SizeCell));
                            break;
                        case 'f':
                            fragileBlocks.Add(new FragileBlock(new Point(i * scale, j * scale), SizeCell));
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

        private void ReadTextFile()
        {
            if (map == null)
            {
                map = File.ReadAllLines(@"Resources\map.txt", System.Text.Encoding.Default);
            }
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

                if (map[posY][posX] == 'g')
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

            if (CheckKolobokСollisions(Kolobok, walls))
            {
                PreventCollision();
            }

            if (CheckKolobokСollisions(Kolobok, rivers))
            {
                PreventCollision();
            }

            if (CheckKolobokСollisions(Kolobok, fragileBlocks))
            {
                PreventCollision();
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

            if (CheckKolobokСollisions(Kolobok, enemyBullets))
            {
                GameOver();
            }

        }

        private void UpdateTanks()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                int chanceOfTurning = rand.Next(0, 100);

                if (chanceOfTurning == 99)
                {
                    tanks[i].SelectTurn();
                }

                for (int z = 0; z < tanks.Count; z++)
                {
                    if (tanks[i].hitBox.IntersectsWith(tanks[z].hitBox))
                    {
                        if (i == z)
                        {
                            break;
                        }
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

                tanks[i].continuousMove(dt);
            }

            if (CheckСollisions(tanks, walls, out GameObject tank1, out GameObject wall1))
            {
                ((Tank)tank1).Turn();
                ((Tank)tank1).continuousMove(dt);
            }

            if (CheckСollisions(tanks, rivers, out GameObject tank2, out GameObject rivers1))
            {
                ((Tank)tank2).Turn();
                ((Tank)tank2).continuousMove(dt);

            }

            if (CheckСollisions(tanks, fragileBlocks, out GameObject tank3, out GameObject block))
            {
                ((Tank)tank3).Turn();
                ((Tank)tank3).continuousMove(dt);
            }


            if (tanks.Count == 0)
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
            }

            for (int i = 0; i < enemyBullets.Count; i++)
            {
                enemyBullets[i].continuousMove(dt);
            }

            if (CheckСollisions(bullets, walls, out GameObject bullet1, out GameObject wall1))
            {
                bullets.Remove((Bullet)bullet1);
            }

            if (CheckСollisions(bullets, fragileBlocks, out GameObject bullet2, out GameObject block1))
            {
                bullets.Remove((Bullet)bullet2);
                fragileBlocks.Remove((FragileBlock)block1);
            }

            if (CheckСollisions(enemyBullets, walls, out GameObject enemyBullet1, out GameObject wall2))
            {
                enemyBullets.Remove((Bullet)enemyBullet1);
            }

            if (CheckСollisions(enemyBullets, fragileBlocks, out GameObject enemyBullet2, out GameObject block2))
            {
                enemyBullets.Remove((Bullet)enemyBullet2);
                fragileBlocks.Remove((FragileBlock)block2);
            }

            if (CheckСollisions(bullets, tanks, out GameObject bullet3, out GameObject tank))
            {
                bullets.Remove((Bullet)bullet3);
                tanks.Remove((Tank)tank);
            }

            if (CheckСollisions(bullets, enemyBullets, out GameObject bullet4, out GameObject enemyBullet))
            {
                bullets.Remove((Bullet)bullet4);
                enemyBullets.Remove((Bullet)enemyBullet);
            }
        }

        private bool CheckKolobokСollisions(Kolobok kolobok, IEnumerable<GameObject> gameObjects)
        {
            foreach (GameObject i in gameObjects)
            {
                if (i.hitBox.IntersectsWith(kolobok.hitBox))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckСollisions(IEnumerable<GameObject> gameObjects1, IEnumerable<GameObject> gameObjects2, out GameObject gameObjectOut1, out GameObject gameObjectOut2)
        {
            foreach (GameObject i in gameObjects1)
            {
                foreach (GameObject j in gameObjects2)
                {
                    if (i.hitBox.IntersectsWith(j.hitBox))
                    {
                        gameObjectOut1 = i;
                        gameObjectOut2 = j;
                        return true;
                    }
                }
            }
            gameObjectOut1 = null;
            gameObjectOut2 = null;
            return false;
        }

        private void PreventCollision()
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

        public void StopTimer(object sender, EventArgs e)
        {
            Timer.Stop();
        }

        public void Reset()
        {
            walls = new List<Wall>();
            tanks = new List<Tank>();
            apples = new List<Apple>();
            enemyBullets = new List<Bullet>();
            bullets = new List<Bullet>();
            rivers = new List<River>();
            fragileBlocks = new List<FragileBlock>();
            Score = 0;
            Updatescore();
            SpawnObjectsOnField(5, 5);
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

