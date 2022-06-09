using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    class Bullet:IObject
    {
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public int Damage { get; set; }
        

        private Coordinate _position;
        public Collider HitBox { get; set; }
        

        public Coordinate Position
        {
            get
            {
                return _position;
            }
            private set
            {
                _position = value;
            }
        }

        public string Type { get; }

        public void MoveBullet(double x, double y)
        {
            _position = new Coordinate(x , y );
            HitBox.Position = new Coordinate(x+2.5, y+2.5);
        }

        public void Update()
        {
            this.MoveBullet(this.Position.X + this.SpeedX, this.Position.Y + this.SpeedY);
        }

        public Bullet( double x ,double y, int _damage, double Radius,Coordinate center)
        {
            SpeedX = 10*x;
            SpeedY = 10*y;
            Damage = _damage;
            HitBox = new Collider(Radius,new Coordinate(center.X + 2.5, center.Y + 2.5));
            _position = center;
            Type = "Bullet";
        }
    }
}
