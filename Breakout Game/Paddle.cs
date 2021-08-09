using System.Drawing;
using System.Windows.Forms;

namespace Breakout_Game
{
    public class Paddle
    {
        public RectangleF Rectangle { get; private set; }
        private readonly int LENGTH = 200;
        private readonly int SPEED = 15;
        public Paddle(Size size)
        {
            Rectangle = new RectangleF(new PointF((size.Width - LENGTH) / 2, size.Height - 15), new SizeF(LENGTH, 15));
        }
        public void Move(int direction, PictureBox DisplayBox)
        {
            if (Rectangle.Left >= 0 && Rectangle.Right <= DisplayBox.Right)
            {
                Rectangle = new RectangleF(new PointF(Rectangle.X + direction * SPEED, Rectangle.Y), new SizeF(LENGTH, 15));
            }
            //DisplayBox.Right is 11 more that it should be
            if (Rectangle.Right > DisplayBox.Right - 11)
            {
                Rectangle = new RectangleF(new PointF(DisplayBox.Right - Rectangle.Size.Width - 11, Rectangle.Y), new SizeF(LENGTH, 15));
            }
            if (Rectangle.Left < 0)
            {
                Rectangle = new RectangleF(new PointF(0, Rectangle.Y), new SizeF(LENGTH, 15));
            }
        }
    }
}
