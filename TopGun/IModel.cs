using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    public interface IModel
    {
        void Update();
        event EventHandler <OutputCoordinate> Updated;
        void MovePlayer(int dir );
        void Shoot(int MouseX, int MouseY);
    }
    
    public class OutputCoordinate
    {
        public int Count { get; set; }
        public Coordinate CoordinatePlayer { get; set; }
        public Dictionary <int, IObject> Object { get; set; }
        
        public int Radius { get; set; }
    }
}
