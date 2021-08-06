using System.Drawing;
using System.Windows.Forms;

namespace Breakout_Game
{
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
}
