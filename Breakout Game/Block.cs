using System.Drawing;

namespace Breakout_Game
{
    public class Block
    {
        public RectangleF Rectangle { get; private set; }
        public Color Colour { get; private set; }
        private readonly int TopGap = 3;

        public Block(int column, int row, Size size, int MaxColumn, int MaxRow)
        {
            int RowMultiplier = size.Height / ((MaxRow + TopGap) * 2); //goes up to half way and leaves a gap of 2 at the top
            int ColumnMultiplier = size.Width / MaxColumn; //Width of block takes up entire form width

            Colour = GetColour(row);
            //ColumnMultiplier + 1, the + 1 creates a 1 pixel black line so the user can see the end of each block.
            Rectangle = new RectangleF(new PointF(column * (ColumnMultiplier + 1), (row + TopGap) * RowMultiplier), new SizeF(ColumnMultiplier, RowMultiplier));
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

        public static Block[,] CreateArray(Size size, int COLUMN, int ROW)
        {
            Block[,] blocks = new Block[COLUMN, ROW];
            //creates ROW and COLUMN in 2D array.
            for (int i = 0; i < COLUMN; i++)
            {
                for (int j = 0; j < ROW; j++)
                {
                    blocks[i, j] = new Block(i, j, size, COLUMN, ROW);
                }
            }
            return blocks;
        }
    }
}
