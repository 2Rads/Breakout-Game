using System;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout_Game
{
    public partial class BreakoutForm : Form
    {
        private readonly int ROW = 8;
        private readonly int COLUMN = 10;
        private int lives = 5;
        private int score;

        private bool LEFT = false;
        private bool RIGHT = false;

        private Block[,] blocks;
        private Paddle paddle;
        private Ball ball;

        public BreakoutForm()
        {
            InitializeComponent();

            blocks = new Block[COLUMN, ROW];
            //creates 8 rows with 15 columns
            for (int i = 0; i < COLUMN; i++)
            {
                for (int j = 0; j < ROW; j++)
                {
                    blocks[i, j] = new Block(i, j, DisplayBox.Size, COLUMN, ROW);
                }
            }
            score = 0;
            paddle = new Paddle(DisplayBox.Size);
            ball = new Ball(DisplayBox.Size);
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
                        e.Graphics.FillRectangle(brush, blocks[i, j].block);
                    }
                }
            }
            brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, paddle.paddle);
            e.Graphics.FillEllipse(brush, ball.ball);
        }

        private void BreakoutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                RIGHT = true;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                LEFT = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DetectBallBlockCollision();
            DetectBallPaddleCollision();
            DetectBallAndEdges();
            ball.move();

            if (LEFT) paddle.move(-1, DisplayBox);
            if (RIGHT) paddle.move(1, DisplayBox);

            DisplayBox.Invalidate();
            DisplayBox.Update();
        }
        private void DetectBallPaddleCollision()
        {
            if (ball.ball.IntersectsWith(paddle.paddle) && ball.velocity.Y > 0)
            {

                float BallCentre = ball.ball.X + ball.ball.Width / 2;
                float PaddleCentre = paddle.paddle.X + paddle.paddle.Width / 2;

                float ratio = (BallCentre - PaddleCentre) / (paddle.paddle.Width / 2);

                ball.ChangeAngle(ratio);
            }
        }
        private void DetectBallAndEdges()
        {
            if (ball.ball.Left <= 0 || ball.ball.Right >= DisplayBox.Right - 11)//-11 as boundary error with right side of wall
            {
                ball.ChangeDirection(1, 0);
            }
            if (ball.ball.Top <= 0)
            {
                ball.ChangeDirection(0, 1);
            }
            if (ball.IsOffScreen(DisplayBox.Size.Height))
            {
                lives--;
                LivesLbl.Text = $"Lives: {lives}";
                if (lives <= 0)
                {
                    LoseScreen();
                }
                ball = new Ball(DisplayBox.Size);
            }
        }
        private void LoseScreen()
        {
            ball = null;
            Timer.Enabled = false;
        }
        private void DetectBallBlockCollision()
        {
            for (int i = 0; i < COLUMN; i++)
            {
                for (int j = 0; j < ROW; j++)
                {
                    if (blocks[i, j] != null)
                    {
                        RectangleF intersection = RectangleF.Intersect(ball.ball, blocks[i, j].block);
                        if (intersection.IsEmpty)
                        {
                            continue;
                        }
                        if (intersection.Height > intersection.Width)
                        {
                            if (ball.ball.Right == intersection.Right && ball.velocity.X > 0 || ball.ball.Left == intersection.Left && ball.velocity.X < 0)
                            {
                                ball.ChangeDirection(1, 0);
                                blocks[i, j] = null;
                                score++;
                                ScoreLbl.Text = $"Score: {score}";
                            }
                        }
                        else
                        {
                            if (ball.ball.Top == intersection.Top && ball.velocity.Y < 0 || ball.ball.Bottom == intersection.Bottom && ball.velocity.Y > 0)
                            {
                                ball.ChangeDirection(0, 1);
                                blocks[i, j] = null;
                                score++;
                                ScoreLbl.Text = $"Score: {score}";
                            }
                        }
                    }
                }
            }
        }

        private void BreakoutForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                RIGHT = false;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                LEFT = false;
            }
        }
    }
}
