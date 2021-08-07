using System;
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

            velocity = new PointF(2, 2);//default speed is 2 in x, 2 in y.
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
        public void ChangeAngle(float ratio)
        {
            double speed = GetSpeed(velocity.X, velocity.Y) * 1.1;
            speed = Math.Min(speed, 10);

            double angle = Math.PI * ratio * 70 / 180.0;
            double cosangle = -Math.Cos(angle);
            double sinangle = Math.Sin(angle);
            if (ratio > 0.8)
            {
                velocity = new PointF((float)(Math.Sqrt(3) * speed / 2), (float)(-speed / 2));
            }
            else if (ratio < -0.8)
            {
                velocity = new PointF((float)(-Math.Sqrt(3) * speed / 2), (float)(-speed / 2));
            }
            else
            {
                velocity = new PointF((float)(sinangle * speed), (float)(cosangle * speed));
            }
        }
        private static double GetSpeed(float x, float y)
        {
            return Math.Sqrt(x * x + y * y);
        }
        public bool IsOffScreen(int height)
        {
            return ball.Bottom >= height;
        }
    }
}
