using System;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout_Game
{
    public partial class BreakoutForm : Form
    {
        private Block[,] blocks = new Block[15, 8];
        private int row = 8;
        private int column = 15;
        private Paddle paddle;
        private Ball ball;
        private int lives = 5;
        public BreakoutForm()
        {
            InitializeComponent();
            //creates 8 rows with 15 columns
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    blocks[i, j] = new Block(i, j);
                }
            }
            paddle = new Paddle(DisplayBox.Size);
            ball = new Ball(DisplayBox.Size);
        }
        private void DisplayBox_Paint(object sender, PaintEventArgs e)
        {
            Brush brush;
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
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
                paddle.move(1, DisplayBox);
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                paddle.move(-1, DisplayBox);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DetectBallBlockCollision();
            DetectBallPaddleCollision();
            DetectBallAndEdges();
            ball.move();
            DisplayBox.Invalidate();
            DisplayBox.Update();
        }
        private void DetectBallPaddleCollision()
        {
            if (ball.ball.IntersectsWith(paddle.paddle) && /*ball.ball.Bottom <= paddle.paddle.Top &&*/ ball.velocity.Y > 0)
            {
                ball.ChangeDirection(0, 1);
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
            if (ball.ball.Bottom >= DisplayBox.Height)
            {
                lives--;
            }
        }
        private void DetectBallBlockCollision()
        {
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if(blocks[i,j] != null /*&& ball.ball.IntersectsWith(blocks[i, j].block)*/)
                    {

                        RectangleF intersection = RectangleF.Intersect(ball.ball, blocks[i, j].block);
                        if (intersection.IsEmpty)
                        {
                            continue;
                        }
                        if (intersection.Height > intersection.Width)
                        {
                            
                            if (ball.ball.Right == intersection.Right && ball.velocity.X > 0)
                            {
                                ball.ChangeDirection(1, 0);
                                blocks[i, j] = null;
                            }
                            else if (ball.ball.Left == intersection.Left && ball.velocity.X < 0)
                            {
                                ball.ChangeDirection(1, 0);
                                blocks[i, j] = null;
                            }
                        }
                        else if(intersection.Width > intersection.Height)
                        {
                            if (ball.ball.Top == intersection.Top && ball.velocity.Y < 0)
                            {
                                ball.ChangeDirection(0, 1);
                                blocks[i, j] = null;
                            }
                            else if (ball.ball.Bottom == intersection.Bottom && ball.velocity.Y > 0)
                            {
                                ball.ChangeDirection(0, 1);
                                blocks[i, j] = null;
                            }
                        }
                        //if (ball.ball.Top == intersection.Top && ball.velocity.Y < 0)
                        //{
                        //    ball.ChangeDirection(0, 1);
                        //    blocks[i, j] = null;
                        //}
                        //if (ball.ball.Bottom == intersection.Bottom && ball.velocity.Y > 0)
                        //{
                        //    ball.ChangeDirection(0, 1);
                        //    blocks[i, j] = null;
                        //}
                        //if (ball.ball.Right == intersection.Right && ball.velocity.X > 0)
                        //{
                        //    ball.ChangeDirection(1, 0);
                        //    blocks[i, j] = null;
                        //}
                        //if (ball.ball.Left == intersection.Left && ball.velocity.X < 0)
                        //{
                        //    ball.ChangeDirection(1, 0);
                        //    blocks[i, j] = null;
                        //}



                        //if(ball.ball.Bottom >= blocks[i, j].block.Top && ball.velocity.Y>0)
                        //{
                        //    ball.ChangeDirection(0, 1);
                        //    blocks[i, j] = null;
                        //}
                        //else if (ball.ball.Top <= blocks[i, j].block.Bottom && ball.velocity.Y < 0)
                        //{
                        //    ball.ChangeDirection(0, 1);
                        //    blocks[i, j] = null;
                        //}
                        //else if (ball.ball.Right >= blocks[i, j].block.Left && ball.velocity.X>0)
                        //{
                        //    ball.ChangeDirection(1, 0);
                        //    blocks[i, j] = null;
                        //}
                        //else if (ball.ball.Left <= blocks[i, j].block.Right && ball.velocity.X < 0)
                        //{
                        //    ball.ChangeDirection(1, 0);
                        //    blocks[i, j] = null;
                        //}
                    }
                }
            }
        }

    }
}
