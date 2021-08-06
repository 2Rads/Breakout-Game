using System.Drawing;

namespace Breakout_Game
{
    public class Ball
    {
        public RectangleF ball { get; private set; }    //treating ball as rectangle, helps with collision detection.
        public PointF velocity { get; private set; }

        public Ball(Size size)
        {
            ball = new RectangleF(new PointF(size.Width / 2 - 15, size.Height / 2), new SizeF(30, 30));
            velocity = new PointF(2, 2);
        }
        public void move()
        {
            ball = new RectangleF(new PointF(ball.X + velocity.X, ball.Y + velocity.Y), new SizeF(30, 30));
        }
        public void ChangeDirection(int x, int y)
        {
            //1 means change direction, 0 means don't change dirction
            if (x == 1)
            {
                velocity = new PointF(-velocity.X, velocity.Y);
            }
            if (y == 1)
            {
                velocity = new PointF(velocity.X, -velocity.Y);
            }
        }
    }
}
