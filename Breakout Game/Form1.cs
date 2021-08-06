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

            Pen pen = new Pen(Color.White, 1);
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
            ball.move();
        }
    }
    public class Block
    {
        public RectangleF block { get; private set; }
        public Color Colour { get; private set; }
        public bool hit { get; private set; }

        public Block(int column, int row)
        {
            int RowMultiplier = 35;//appropriate sizes for width and height of a block
            int ColumnMultiplier = 68;


            Colour = GetColour(row);
            hit = false;

            block = new RectangleF(new PointF(column * (ColumnMultiplier+1), row * RowMultiplier), new SizeF(ColumnMultiplier, RowMultiplier));
        }
        private static Color GetColour(int row)
        {
            switch (row)
            {
                case 0:
                    return Color.Pink;
                case 1:
                    return Color.Red;
                case 2:
                    return Color.Orange;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.Green;
                case 5:
                    return Color.Blue;
                case 6:
                    return Color.Purple;
                default:
                    return Color.Aqua;
            }
        }
    }
    public class Paddle
    {
        public RectangleF paddle { get; private set; }
        public Paddle(Size size)
        {
        
            paddle = new RectangleF(new PointF( size.Width/2 - 75, size.Height - 20), new SizeF(150, 20));
        }
        public void move(int direction, PictureBox DisplayBox)
        {
            int speed = 8;
            if (paddle.Left >= 0 && paddle.Right <= DisplayBox.Right)
            {
                paddle = new RectangleF(new PointF(paddle.X + direction * speed, paddle.Y), new SizeF(150, 20));
            }
            //DisplayBox.Right is 11 more that it should be
            if (paddle.Right > DisplayBox.Right-11)
            {
                paddle = new RectangleF(new PointF(DisplayBox.Right - paddle.Size.Width - 11, paddle.Y), new SizeF(150, 20));
            }
            if (paddle.Left < 0)
            {
                paddle = new RectangleF(new PointF(0, paddle.Y), new SizeF(150, 20));
            }
        }

    }

    public class Ball
    {
        public RectangleF ball { get; private set; }    //treating ball as rectangle, helps with collision detection.
        private PointF velocity;
                
        public Ball(Size size)
        {
            ball = new RectangleF(new PointF(size.Width / 2 - 15, size.Height/2), new SizeF(30, 30));
            velocity = new PointF(2, 2);
        }
        public void move()
        {
            ball = new RectangleF(new PointF(ball.X + velocity.X, ball.Y + velocity.Y), new SizeF(30, 30));
        }
    }
}
