using System;
using System.Drawing;

namespace Breakout_Game
{
    public class Ball
    {
        public RectangleF ball { get; private set; }    //treating ball as rectangle, helps with collision detection.
        public PointF velocity { get; private set; }
        private readonly int Diameter = 30;
        private readonly int MaxSpeed = 10;
        private readonly float SpeedIncrement = 1.005f;
        public Ball(Size size)
        {
            ball = new RectangleF(new PointF((size.Width - Diameter) / 2 , size.Height / 2), new SizeF(Diameter, Diameter));

            velocity = new PointF(2, 2);//start speed is 2 in x, 2 in y.
        }
        public void move()
        {
            ball = new RectangleF(new PointF(ball.X + velocity.X, ball.Y + velocity.Y), new SizeF(Diameter, Diameter));
        }
        public void ChangeDirection(bool x, bool y)
        {
            //true means reflect in that axis.
            if (x)
            {
                velocity = new PointF(-velocity.X, velocity.Y);
            }
            if (y)
            {
                velocity = new PointF(velocity.X, -velocity.Y);
            }
        }
        public void ChangeAngle(float ratio)
        {
            double speed = GetSpeed(velocity.X, velocity.Y);

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
        public void IncreaseSpeed()
        {
            if (!(GetSpeed(velocity.X, velocity.Y) >= MaxSpeed))
            {
                velocity = new PointF(velocity.X*SpeedIncrement, velocity.Y*SpeedIncrement);
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
