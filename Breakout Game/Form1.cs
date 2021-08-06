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
        public BreakoutForm()
        {
            InitializeComponent();

            

            //creates 8 rows with 15 columns
            for(int i = 0; i< column; i++)
            {
                for(int j = 0; j< row; j++)
                {
                    blocks[i, j] = new Block(i, j, DisplayBox.Size);
                }
            }
            paddle = new Paddle(DisplayBox.Size);
            //calls the paint function to display
            DisplayBox.Invalidate();
            DisplayBox.Update();
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


        }
    }
    public class Block
    {
        public RectangleF block { get; private set; }
        public Color Colour { get; private set; }
        public bool hit { get; private set; }

        public Block(int column, int row, Size size)
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
            }
            return Color.Aqua;
        }
    }
    public class Paddle
    {
        public RectangleF paddle { get; private set; }
        public Paddle(Size size)
        {
        
            paddle = new RectangleF(new PointF( size.Width/2 - 75, size.Height - 20), new SizeF(150, 20));
        }
    }
}
