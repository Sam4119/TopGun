using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    class Collider
    {
        public int Radius { get; set; }
        private Coordinate _position;
        public Collider(int Radius,Coordinate coordinate)
        {
            this.Radius = Radius;
            this._position = coordinate;
        }
        
        public bool IsCollided(int r, int CY,int CX)  
        {
            bool collided = false;
            if (Radius + r < Math.Sqrt(Math.Pow(_position.Y - CY, 2) + Math.Pow(_position.X - CX, 2)))
            {
                collided = true;
            }

            return collided;
        }
    }
}
