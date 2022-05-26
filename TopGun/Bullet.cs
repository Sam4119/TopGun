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
        public Bullet( int _damage, int Radius,Coordinate center)
        {
            SpeedX = 5;
            SpeedY = 5;
            Damage = _damage;
            HitBox = new Collider(Radius, center);
            _position = new Coordinate(center.X,center.Y);

        }
    }
}
