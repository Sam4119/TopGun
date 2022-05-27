using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    class Bullet
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
            set
            {
                _position = value;
            }
        }
        public Bullet( double x ,double y, int _damage, int Radius,Coordinate center)
        {
            SpeedX = 5*x;
            SpeedY = 5*y;
            Damage = _damage;
            HitBox = new Collider(Radius, center);
            _position = new Coordinate(center.X + 25 ,center.Y + 25);

        }
    }
}
