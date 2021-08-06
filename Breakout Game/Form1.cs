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
    public partial class Breakout : Form
    {
        public Breakout()
        {
            InitializeComponent();

            Block[,] blocks = new Block[8, 15];

            //creates 8 rows with 15 columns
            for(int i = 0; i<8; i++)
            {
                for(int j = 0; j<15; j++)
                {
                    blocks[i, j] = new Block(i, j);
                }
            }
        }
    }
    public class Block
    {
        public RectangleF block { get; private set; }
        public Color Colour { get; private set; }
        public bool hit { get; private set; }

        public Block(int row, int column)
        {
            int RowMultiplier = 10;
            int ColumnMultiplier = 10;
            hit = false;
            block = new RectangleF(new PointF(row * RowMultiplier, column * ColumnMultiplier), new SizeF(10,10));
        }
    }
}
