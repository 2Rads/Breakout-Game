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

            //calls the paint function to display
            DisplayBox.Invalidate();
            DisplayBox.Update();
        }
        private void DisplayBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Brush brush = new SolidBrush(blocks[i, j].Colour);
                    e.Graphics.FillRectangle(brush, blocks[i, j].block);
                }
            }
        }
    }
    public class Block
    {
        public RectangleF block { get; private set; }
        public Color Colour { get; private set; }
        public bool hit { get; private set; }

        public Block(int column, int row, Size size)
        {
            int RowMultiplier = size.Height / 16;
            int ColumnMultiplier = size.Width/16;


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
}
