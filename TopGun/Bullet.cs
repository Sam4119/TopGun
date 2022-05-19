using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    class Bullet
    {
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }
        public int Damage { get; set; }

        private Coordinate _position;
        private Collider _hitBox;

        public Bullet(int _speedX,int _speedY, int _damage, int Radius,Coordinate center)
        {
            SpeedX = _speedX;
            SpeedY = _speedY;
            Damage = _damage;
            _hitBox = new Collider(Radius, center);
            _position = new Coordinate(center.X,center.Y);

        }
    }
}
