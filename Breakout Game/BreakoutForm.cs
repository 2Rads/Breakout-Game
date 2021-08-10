using System;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout_Game
{
    public partial class BreakoutForm : Form
    {
        private readonly int ROW = 8;
        private readonly int COLUMN = 10;
        private int lives;
        private int score;
        private bool paused = false;
        private bool EndGame = false;

        private bool PADDLELEFT = false;
        private bool PADDLERIGHT = false;

        Button EndGameRestartBtn;

        private Block[,] blocks;
        private Paddle paddle;
        private Ball ball;

        public BreakoutForm()
        {
            InitializeComponent();
            LoadDefault();
        }
        private void LoadDefault()
        {
            score = 0;
            lives = 5;
            blocks = Block.CreateArray(DisplayBox.Size, COLUMN, ROW);
            paddle = new Paddle(DisplayBox.Size);
            ball = new Ball(DisplayBox.Size);
            Timer.Enabled = true;
            PlayPauseBtn.Image = Properties.Resources.Pause;
            paused = false;
            EndGame = false;
            if (EndGameRestartBtn != null)
            {
                EndGameRestartBtn.Visible = false;
                EndGameRestartBtn.Enabled = false;
            }
            WinLbl.Visible = false;
            ScoreLbl.Text = "Score: 0";
            LivesLbl.Text = $"Lives: {lives}";
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //DetectBall will check and change the direction of the ball.
            DetectBallBlockCollision();
            DetectBallPaddleCollision();
            DetectBallAndEdges();

            ball.Move();
            ball.IncreaseSpeed();

            if (PADDLELEFT) paddle.Move(-1, DisplayBox);
            if (PADDLERIGHT) paddle.Move(1, DisplayBox);

            DisplayBox.Invalidate();
            DisplayBox.Update();
        }
        private void DisplayBox_Paint(object sender, PaintEventArgs e)
        {
            Brush brush;
            for (int i = 0; i < COLUMN; i++)
            {
                for (int j = 0; j < ROW; j++)
                {
                    if (blocks[i, j] != null)
                    {
                        brush = new SolidBrush(blocks[i, j].Colour);
                        e.Graphics.FillRectangle(brush, blocks[i, j].Rectangle);
                    }
                }
            }
            brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, paddle.Rectangle);
            e.Graphics.FillEllipse(brush, ball.Rectangle);
        }

        private void DetectBallPaddleCollision()
        {
            //if it detects a collision, it change the angle of the ball depending on where it hit the paddle.
            if (ball.Rectangle.IntersectsWith(paddle.Rectangle) && ball.Velocity.Y > 0)
            {
                float BallCentre = ball.Rectangle.X + ball.Rectangle.Width / 2;
                float PaddleCentre = paddle.Rectangle.X + paddle.Rectangle.Width / 2;

                float ratio = (BallCentre - PaddleCentre) / (paddle.Rectangle.Width / 2);

                ball.ChangeAngle(ratio);
            }
        }
        private void DetectBallAndEdges()
        {
            //if it detects a collision, the ball will reflect.
            if (ball.Rectangle.Left <= 0 || ball.Rectangle.Right >= DisplayBox.Right - 11)//-11 as boundary error with right side of wall
            {
                ball.ChangeDirection(true, false);
            }
            if (ball.Rectangle.Top <= 0)
            {
                ball.ChangeDirection(false, true);
            }
            if (ball.IsOffScreen(DisplayBox.Size.Height))
            {
                lives--;
                LivesLbl.Text = $"Lives: {lives}";
                if (lives <= 0)
                {
                    EndScreen(false);
                }
                ball = new Ball(DisplayBox.Size);
            }
        }
        private void DetectBallBlockCollision()
        {
            //if it detects a collision, the ball will reflect.
            bool BlocksLeft = false;
            for (int i = 0; i < COLUMN; i++)
            {
                for (int j = 0; j < ROW; j++)
                {
                    if (blocks[i, j] != null)
                    {
                        BlocksLeft = true;
                        RectangleF intersection = RectangleF.Intersect(ball.Rectangle, blocks[i, j].Rectangle);
                        if (intersection.IsEmpty)
                        {
                            continue;
                        }
                        if (intersection.Height > intersection.Width)
                        {
                            if (ball.Rectangle.Right == intersection.Right && ball.Velocity.X > 0 || ball.Rectangle.Left == intersection.Left && ball.Velocity.X < 0)
                            {
                                ball.ChangeDirection(true, false);
                                DestroyBlock(i, j);
                            }
                        }
                        else
                        {
                            if (ball.Rectangle.Top == intersection.Top && ball.Velocity.Y < 0 || ball.Rectangle.Bottom == intersection.Bottom && ball.Velocity.Y > 0)
                            {
                                ball.ChangeDirection(false, true);
                                DestroyBlock(i, j);
                            }
                        }
                    }
                }
            }
            //if no blocks are left, it will end the game.
            if (!BlocksLeft)
            {
                EndScreen(true);
            }
        }
        private void DestroyBlock(int i, int j)
        {
            blocks[i, j] = null;
            score++;
            ScoreLbl.Text = $"Score: {score}";
        }

        private void BreakoutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                PADDLERIGHT = true;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                PADDLELEFT = true;
            }
        }
        private void BreakoutForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                PADDLERIGHT = false;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                PADDLELEFT = false;
            }
        }
        private void BreakoutForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;    //triggers keydown and up events to allow paddle to move
        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            //disable then enabling brings focus to form so it can detect keyboard clicks.
            RestartBtn.Enabled = false;
            RestartBtn.Enabled = true;

            LoadDefault();
        }
        private void PlayPauseBtn_Click(object sender, EventArgs e)
        {
            if (EndGame)
            {
                return;
            }
            //disable then enabling brings focus to form so it can detect keyboard clicks.
            PlayPauseBtn.Enabled = false;
            PlayPauseBtn.Enabled = true;

            if (paused)
            {
                PlayPauseBtn.Image = Properties.Resources.Pause;
            }
            else
            {
                PlayPauseBtn.Image = Properties.Resources.Play;
            }

            paused = !paused;
            Timer.Enabled = !Timer.Enabled;

        }

        private void EndScreen(bool win)
        {
            EndGame = true;
            Timer.Enabled = false;

            EndGameRestartBtn = new Button();
            EndGameRestartBtn.Image = Properties.Resources.RestartImg;
            EndGameRestartBtn.Size = new Size(EndGameRestartBtn.Image.Width, EndGameRestartBtn.Image.Height);
            EndGameRestartBtn.Left = (DisplayBox.Width - EndGameRestartBtn.Width) / 2;
            EndGameRestartBtn.Top = (DisplayBox.Height - EndGameRestartBtn.Height) / 2;

            WinLbl.Text = win ? "You Win" : "You Lose";
            WinLbl.Visible = true;

            DisplayBox.Controls.Add(EndGameRestartBtn);
            EndGameRestartBtn.Click += new EventHandler(RestartBtn_Click);
        }
    }
}
