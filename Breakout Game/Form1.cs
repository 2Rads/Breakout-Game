using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public BreakoutForm()
        {
            InitializeComponent();

            

            //creates 8 rows with 15 columns
            for(int i = 0; i< column; i++)
            {
                for(int j = 0; j< row; j++)
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
                    brush = new SolidBrush(blocks[i, j].Colour);
                    e.Graphics.FillRectangle(brush, blocks[i, j].block);
                }
            }
            brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, paddle.paddle);
            e.Graphics.FillEllipse(brush, ball.ball);
        }

        private void BreakoutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
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
            DetectBallPaddleCollision();
            ball.move();
            DisplayBox.Invalidate();
            DisplayBox.Update();
        }
        private void DetectBallPaddleCollision()
        {
            if (ball.ball.IntersectsWith(paddle.paddle) && ball.ball.Bottom <= paddle.paddle.Top)
            {
                ball.ChangeDirection(0,1);
            }
        }

    }
}
