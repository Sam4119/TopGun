using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    class Collider
    {
        public double Radius { get; set; }
        public Coordinate Position;
        public Collider(double Radius,Coordinate coordinate)
        {
            this.Radius = Radius;
            this.Position = coordinate;
        }
        
        public bool IsCollided(double r, double CY,double CX)  
        {
            bool collided = false;
            if (Radius + r >= Math.Sqrt(Math.Pow(Position.Y - CY, 2) + Math.Pow(Position.X - CX, 2)))
            {
                collided = true;
            }
            //решить проблему с геометрией
            return collided;
        }
    }
}
