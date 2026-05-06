using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MazeGame
{
    public partial class Form1 : Form
    {
        int enemy2level = 15;
        string filePath = "highscore.txt";
        bool gameRunning;
        bool gameStarted;
        int[,] maze;
        int gridSize = 9;
        double gridP = 0.65;
        double prob = 0.50;
        double spawnProbAdd = 0.50;
        private Random rand = new Random();
        int tick;
        int level;
        int highscore;
        int size;
        int xOffset;
        int yOffset;
        int cellSize;

        class Entity
        {
            public Point position;
            public Point lastPos;
            public Point direction;
            public int gameTicksPerMove;
        }

        Entity player;
        Entity[] enemies;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1280;
            this.Height = 720;
            highscore = LoadHighScore();
            highscoreLabel.Text = "Highscore: " + highscore;
            nextLvlButton.Visible = false;
            panel1.Location = new Point(0, 0);
            panel2.Location = new Point(0, 0);
            this.KeyPreview = true;
            playButton.Visible = true;
            titleLabel.Visible = true;
            subtitleLabel.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            gameRunning = false;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
            subtitleLabel.Visible = false;
            titleLabel.Visible = false;
            panel1.Visible = true;
            InitializeGame();
        }

        private void InitializeGame()
        {
            size = (int)(this.Height * gridP);
            xOffset = (this.Width - size) / 2;
            yOffset = (this.Height - size) / 2 - 15;
            cellSize = size / gridSize;

            levelLabel.Text = "Level 1";
            enemyImage2.Visible = false;
            enemyGroupImage.Visible = false;
            gridSize = 9;
            level = 1;

            player = new Entity();
            player.position = new Point(0, 0);
            player.lastPos = new Point(0, 0);
            player.direction = new Point(0, 0);
            player.gameTicksPerMove = 10;

            enemies = new Entity[2];
            enemies[0] = new Entity();
            enemies[0].position = new Point(gridSize - 1, 0);
            enemies[0].lastPos = new Point(gridSize - 1, 0);
            enemies[0].direction = new Point(0, 0);
            enemies[0].gameTicksPerMove = 15;

            enemies[1] = new Entity();
            enemies[1].position = new Point(0, gridSize - 1);
            enemies[1].lastPos = new Point(0, gridSize - 1);
            enemies[1].direction = new Point(0, 0);
            enemies[1].gameTicksPerMove = 15;

            playerImage.Location = new Point(xOffset, yOffset);
            enemyImage.Location = new Point(xOffset + (gridSize - 1) * cellSize, yOffset);
            enemyImage2.Location = new Point(xOffset, yOffset + (gridSize - 1) * cellSize);

            playerImage.Width = cellSize;
            playerImage.Height = cellSize;

            enemyImage.Width = cellSize;
            enemyImage.Height = cellSize;

            enemyImage2.Width = cellSize;
            enemyImage2.Height = cellSize;

            enemyGroupImage.Width = cellSize;
            enemyGroupImage.Height = cellSize;

            GenerateMaze();
            panel1.Invalidate();
            panel1.Update();
            gameStarted = true;
        }
        private void RestartLevel()
        {
            panel2.Visible = false;
            panel1.Visible = true;
            player.position = new Point(0, 0);
            player.lastPos = new Point(0, 0);
            player.direction = new Point(0, 0);

            enemies[0].position = new Point(gridSize - 1, 0);
            enemies[0].lastPos = new Point(gridSize - 1, 0);
            enemies[0].direction = new Point(0, 0);

            enemies[1].position = new Point(0, gridSize - 1);
            enemies[1].lastPos = new Point(0, gridSize - 1);
            enemies[1].direction = new Point(0, 0);

            tick = 0;
            gameRunning = true;
            gameLoopTimer.Enabled = true;
        }

        private void LevelLost()
        {
            gameRunning = false;
            gameLoopTimer.Enabled = false;
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void LevelWon()
        {
            if (level > highscore)
            {
                highscore = level;
                SaveHighScore(highscore);
                highscoreLabel.Text = "Highscore: " + highscore;
            }
            gameRunning = false;
            gameLoopTimer.Enabled = false;
            nextLvlButton.Visible = true;

        }


        private void ExitToMenu()
        {
            gameStarted = false;
            playButton.Visible = true;
            subtitleLabel.Visible = true;
            titleLabel.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            ExitToMenu();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.Clear(BackColor);
            int cdo = cellSize / 5;


            // Desenez baza tablei
            g.FillRectangle(new SolidBrush(Color.FromArgb(200, 200, 200)),
                new Rectangle(xOffset - cellSize, yOffset - cellSize,
                              cellSize * (gridSize + 2), cellSize * (gridSize + 2)));

            //Desenez iesirea din labirint
            g.FillRectangle(new SolidBrush(BackColor),
               new Rectangle(xOffset + cellSize * gridSize - cdo, yOffset + cellSize * (gridSize - 1) - cdo,
                             cellSize + cdo * 2, cellSize + cdo * 2));
            g.FillRectangle(new SolidBrush(BackColor),
               new Rectangle(xOffset + cellSize * gridSize - cdo, yOffset + cellSize * gridSize - cdo,
                             cellSize + cdo * 2, cellSize + cdo * 2));
            g.FillRectangle(new SolidBrush(BackColor),
               new Rectangle(xOffset + cellSize * (gridSize - 1) - cdo, yOffset + cellSize * gridSize - cdo,
                             cellSize + cdo * 2, cellSize + cdo * 2));

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (maze[i, j] == 0)
                    {
                        g.FillRectangle(new SolidBrush(BackColor),
                        new Rectangle(xOffset + i * cellSize - cdo, yOffset + j * cellSize - cdo,
                                        cellSize + cdo * 2, cellSize + cdo * 2));
                    }
                }
            }

        }

        // Initializarea unui labirint
        private void GenerateMaze()
        {
            maze = new int[gridSize, gridSize];

            // La inceput in labirint se afla doar pereti
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++) maze[i, j] = 1;
            }

            // Se creeaza labirint cu o singura solutie
            RemoveWall(0, 0);

            // Se creeza mai multe solutii
            MakeLoops(prob);
        }

        // Functie recursiva de tip Breadth First care creeaza labirintul
        private void RemoveWall(int i, int j)
        {
            // Punctul (i,j) este transformat in spatiu
            maze[i, j] = 0;

            // Se creeza o lista cu cele 4 directii
            var directions = new List<(int di, int dj)>
            {
                (0, -2), (0, 2), (-2, 0), (2, 0)
            };
            Randomize(directions);

            // Se verifica fiecare directie si se creeza un drum daca se gaseste un perete
            foreach (var (di, dj) in directions)
            {
                int ni = i + di;
                int nj = j + dj;

                if (InBounds(ni, nj) && maze[ni, nj] == 1)
                {
                    maze[i + di / 2, j + dj / 2] = 0;
                    RemoveWall(i + di, j + dj);
                }
            }
        }

        // Verifica daca punctul (i,j) se afla in limitele array-ului maze
        private bool InBounds(int i, int j)
        {
            return i >= 0 && j >= 0 && i < gridSize && j < gridSize;
        }

        // Punem directiile intr-o ordine aleatorie
        private void Randomize(List<(int di, int dj)> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        // Scoatem din peretii labirintului format pentru a creea mai multe drumuri spre iesire
        private void MakeLoops(double probability)
        {
            for (int i = 1; i < gridSize - 1; i++)
            {
                for (int j = 1; j < gridSize - 1; j++)
                {
                    if (maze[i, j] == 1)
                    {
                        if ((maze[i - 1, j] == 0 && maze[i + 1, j] == 0) ||
                            (maze[i, j - 1] == 0 && maze[i, j + 1] == 0))
                        {
                            if (i < gridSize / 3 && j < gridSize / 3)
                            {
                                if (rand.NextDouble() < (probability + spawnProbAdd)) maze[i, j] = 0;
                            }
                            else
                            {
                                if (rand.NextDouble() < probability) maze[i, j] = 0;
                            }

                        }
                    }
                }
            }
        }

        private void gameLoopTimer_Tick(object sender, EventArgs e)
        {
            if (gameRunning)
            {
                

                if (enemies[0].position == player.position)
                    LevelLost();
                if (enemies[1].position == player.position && level >= enemy2level)
                    LevelLost();


                if (tick % player.gameTicksPerMove == 0)
                {
                    Move(player);
                }
                if (player.lastPos == new Point(gridSize - 1, gridSize - 1))
                {
                    LevelWon();
                }


                if (tick % enemies[0].gameTicksPerMove == 0)
                {
                    if (enemies[0].position != player.position)
                        enemies[0].direction = AiBFS(enemies[0].position, player.position);

                    Move(enemies[0]);
                }

                if (tick % enemies[1].gameTicksPerMove == 0 && level >= enemy2level)
                {
                    if (enemies[1].position != player.position)
                        enemies[1].direction = AiBFS(enemies[1].position, player.position);

                    Move(enemies[1]);
                }


                playerImage.Location = Lerp(player.lastPos, player.position, tick % player.gameTicksPerMove, player.gameTicksPerMove, cellSize, xOffset, yOffset);
                enemyImage.Location = Lerp(enemies[0].lastPos, enemies[0].position, tick % enemies[0].gameTicksPerMove, enemies[0].gameTicksPerMove, cellSize, xOffset, yOffset);
                if (level >= enemy2level)
                {
                    enemyImage2.Location = Lerp(enemies[1].lastPos, enemies[1].position, tick % enemies[1].gameTicksPerMove, enemies[1].gameTicksPerMove, cellSize, xOffset, yOffset);
                    if (enemies[0].position == enemies[1].position)
                    {
                        enemyImage.Visible = false;
                        enemyImage2.Visible = false;
                        enemyGroupImage.Location = enemyImage.Location;
                        enemyGroupImage.Visible = true;
                    }
                    else
                    {
                        enemyImage.Visible = true;
                        enemyImage2.Visible = true;
                        enemyGroupImage.Visible = false;
                    }
                }

                    tick++;
            }

        }

        private bool Move(Entity e)
        {
            Point newPos = new Point(e.position.X + e.direction.X, e.position.Y + e.direction.Y);

            if (InBounds(newPos.X, newPos.Y) && maze[newPos.X, newPos.Y] != 1)
            {
                e.lastPos = e.position;
                e.position = newPos;

                return true;
            }

            e.lastPos = e.position;
            return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameStarted && !nextLvlButton.Visible)
            {
                if (e.KeyCode == Keys.W)
                {
                    if (!gameRunning)
                    {
                        tick = 0;
                        gameRunning = true;
                        gameLoopTimer.Enabled = true;
                    }
                    Point newPos = new Point(player.position.X + 0, player.position.Y - 1);
                    if (InBounds(newPos.X, newPos.Y) && maze[newPos.X, newPos.Y] != 1)
                        player.direction = new Point(0, -1);
                }
                if (e.KeyCode == Keys.A)
                {
                    if (!gameRunning)
                    {
                        tick = 0;
                        gameRunning = true;
                        gameLoopTimer.Enabled = true;
                    }
                    Point newPos = new Point(player.position.X - 1, player.position.Y + 0);
                    if (InBounds(newPos.X, newPos.Y) && maze[newPos.X, newPos.Y] != 1)
                        player.direction = new Point(-1, 0);

                }
                if (e.KeyCode == Keys.S)
                {
                    if (!gameRunning)
                    {
                        tick = 0;
                        gameRunning = true;
                        gameLoopTimer.Enabled = true;
                    }
                    Point newPos = new Point(player.position.X + 0, player.position.Y + 1);
                    if (InBounds(newPos.X, newPos.Y) && maze[newPos.X, newPos.Y] != 1)
                        player.direction = new Point(0, 1);
                }
                if (e.KeyCode == Keys.D)
                {
                    if (!gameRunning)
                    {
                        tick = 0;
                        gameRunning = true;
                        gameLoopTimer.Enabled = true;
                    }
                    Point newPos = new Point(player.position.X + 1, player.position.Y + 0);
                    if (InBounds(newPos.X, newPos.Y) && maze[newPos.X, newPos.Y] != 1)
                        player.direction = new Point(1, 0);

                }

            }


        }


        private Point AiBFS(Point start, Point target)
        {
            int[,] visited = new int[gridSize, gridSize];
            Point[,] parent = new Point[gridSize, gridSize];

            Queue<Point> q = new Queue<Point>();
            q.Enqueue(start);
            visited[start.X, start.Y] = 1;

            Point[] dirs = new Point[]
            {
                new Point(1, 0),
                new Point(-1, 0),
                new Point(0, 1),
                new Point(0, -1)
            };

            bool found = false;

            while (q.Count > 0)
            {
                Point curr = q.Dequeue();

                if (curr == target)
                {
                    found = true;
                    break;
                }

                foreach (var d in dirs)
                {
                    Point next = new Point(curr.X + d.X, curr.Y + d.Y);

                    if (InBounds(next.X, next.Y) &&
                        maze[next.X, next.Y] == 0 &&
                        visited[next.X, next.Y] == 0)
                    {
                        visited[next.X, next.Y] = 1;
                        parent[next.X, next.Y] = curr;
                        q.Enqueue(next);
                    }
                }
            }

            if (!found)
                return new Point(0, 0);

            // Intoarcerea de la target la start

            Point step = target;

            while (parent[step.X, step.Y] != start)
            {
                step = parent[step.X, step.Y];
            }

            // Returneaza directia primului pas

            return new Point(step.X - start.X, step.Y - start.Y);
        }

        private Point Lerp(Point A, Point B, int current, int max, int cellSize, int xOffset, int yOffset)
        {

            double t = (double)current / max;

            double lerpedX = A.X + (B.X - A.X) * t;
            double lerpedY = A.Y + (B.Y - A.Y) * t;

            int pixelX = xOffset + (int)(lerpedX * cellSize);
            int pixelY = yOffset + (int)(lerpedY * cellSize); 

            return new Point(pixelX, pixelY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestartLevel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExitToMenu();
        }

        private void nextLvlButton_Click(object sender, EventArgs e)
        {
            level++;
            if (level <= 30) prob -= 0.01;
            if (level % 3 == 0 && level <= 15) gridSize += 2;
            if (level <= 5)
            {
                enemies[0].gameTicksPerMove -= 1;
            }
            else if (level <= 15 && level % 3 == 0)
            {
                enemies[0].gameTicksPerMove -= 1;
            }
            if (player.gameTicksPerMove > enemies[0].gameTicksPerMove) player.gameTicksPerMove = enemies[0].gameTicksPerMove;

            enemies[1].gameTicksPerMove = enemies[0].gameTicksPerMove;


            if (level == enemy2level) enemyImage2.Visible = true;


            nextLvlButton.Visible = false;
            InitializeNextLvl();
        }

        private void InitializeNextLvl()
        {
            size = (int)(this.Height * gridP);
            xOffset = (this.Width - size) / 2;
            yOffset = (this.Height - size) / 2 - 15;
            cellSize = size / gridSize;

            levelLabel.Text = "Level " + level;
            player.position = new Point(0, 0);
            player.lastPos = new Point(0, 0);
            player.direction = new Point(0, 0);

            enemies[0].position = new Point(gridSize - 1, 0);
            enemies[0].lastPos = new Point(gridSize - 1, 0);
            enemies[0].direction = new Point(0, 0);

            enemies[1].position = new Point(0, gridSize - 1);
            enemies[1].lastPos = new Point(0, gridSize - 1);
            enemies[1].direction = new Point(0, 0);

            playerImage.Location = new Point(xOffset, yOffset);
            enemyImage.Location = new Point(xOffset + (gridSize - 1) * cellSize, yOffset);
            enemyImage2.Location = new Point(xOffset , yOffset + (gridSize - 1) * cellSize);


            playerImage.Width = cellSize;
            playerImage.Height = cellSize;

            enemyImage.Width = cellSize;
            enemyImage.Height = cellSize;

            enemyImage2.Width = cellSize;
            enemyImage2.Height = cellSize;

            enemyGroupImage.Width = cellSize;
            enemyGroupImage.Height = cellSize;

            GenerateMaze();
            panel1.Invalidate();
            panel1.Update();
        }

        private void SaveHighScore(int score)
        {
            File.WriteAllText(filePath, score.ToString());
        }

        private int LoadHighScore()
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                int score;

                if (int.TryParse(content, out score))
                    return score;
            }

            return 0; // default if file doesn't exist or invalid
        }

    }
}

