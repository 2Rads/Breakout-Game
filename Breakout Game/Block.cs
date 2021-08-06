using System.Drawing;

namespace Breakout_Game
{
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

            block = new RectangleF(new PointF(column * (ColumnMultiplier + 1), row * RowMultiplier), new SizeF(ColumnMultiplier, RowMultiplier));
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
}
