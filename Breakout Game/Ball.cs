using System;
using System.Drawing;

namespace Breakout_Game
{
    public class Ball
    {
        public RectangleF Rectangle { get; private set; }    //treating ball as rectangle, helps with collision detection.
        public PointF Velocity { get; private set; }
        private readonly int Diameter = 30;
        private readonly int MaxSpeed = 10;
        private readonly float SpeedIncrement = 1.005f;
        public Ball(Size size)
        {
            Rectangle = new RectangleF(new PointF((size.Width - Diameter) / 2, size.Height / 2), new SizeF(Diameter, Diameter));

            Velocity = new PointF(2, 2);//start speed is 2 in x, 2 in y.
        }
        public void Move()
        {
            Rectangle = new RectangleF(new PointF(Rectangle.X + Velocity.X, Rectangle.Y + Velocity.Y), new SizeF(Diameter, Diameter));
        }
        public void ChangeDirection(bool x, bool y)
        {
            //true means reflect in that axis.
            if (x)
            {
                Velocity = new PointF(-Velocity.X, Velocity.Y);
            }
            if (y)
            {
                Velocity = new PointF(Velocity.X, -Velocity.Y);
            }
        }
        public void ChangeAngle(float ratio)
        {
            double speed = GetSpeed(Velocity.X, Velocity.Y);

            double angle = Math.PI * ratio * 70 / 180.0;
            double cosangle = -Math.Cos(angle);
            double sinangle = Math.Sin(angle);
            if (ratio > 0.8)
            {
                Velocity = new PointF((float)(Math.Sqrt(3) * speed / 2), (float)(-speed / 2));
            }
            else if (ratio < -0.8)
            {
                Velocity = new PointF((float)(-Math.Sqrt(3) * speed / 2), (float)(-speed / 2));
            }
            else
            {
                Velocity = new PointF((float)(sinangle * speed), (float)(cosangle * speed));
            }
        }
        public void IncreaseSpeed()
        {
            if (!(GetSpeed(Velocity.X, Velocity.Y) >= MaxSpeed))
            {
                Velocity = new PointF(Velocity.X * SpeedIncrement, Velocity.Y * SpeedIncrement);
            }
        }
        private static double GetSpeed(float x, float y)
        {
            return Math.Sqrt(x * x + y * y);
        }
        public bool IsOffScreen(int height)
        {
            return Rectangle.Bottom >= height;
        }
    }
}
