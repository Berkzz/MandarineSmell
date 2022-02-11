using SFML.Graphics;
using SFML.System;

namespace MandarineSmell
{
    public class Player : Drawable
    {
        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public Player(World world)
        {
            World = world;
        }

        public World World { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Speed { get; set; } = 10;

        private float pitch;
        public float Pitch
        {
            private set
            {
                pitch = value;
            }
            get
            {
                return pitch;
            }
        }

        private float yaw;
        public float Yaw 
        { 
            private set 
            { 
                yaw = value; 
            }
            get 
            {
                return Math.Abs(yaw) % 360 - 180;
            } 
        }

        public void ChangeYaw(float angle)
        {
            yaw += angle;
        }

        public void ChangePitch(float angle)
        {
            if (pitch + angle > 90)
            {
                pitch = 90;
                return;
            }
            if (pitch + angle < -90)
            {
                pitch = -90;
                return;
            }
            pitch += angle;
        }
        
        public void MoveForward(float move)
        {
            var sinCos = Math.SinCos(ConvertToRadians(Yaw));
            X += move * (float)sinCos.Cos;
            Y += move * (float)sinCos.Sin;
            Console.WriteLine(X);
        }

        public void MoveSide(float move)
        {
            var sinCos = Math.SinCos(ConvertToRadians(Yaw));
            Y += move * (float)sinCos.Cos;
            X += move * (float)sinCos.Sin;
            Console.WriteLine(X);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach(var obj in World.Objects)
            {
                var d = obj;
                target.Draw(obj);
            }
        }
    }
}
