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
        
    }

    public class OutputCoordinate
    {
        public Coordinate CoordinatePlayer { get; set; }
        public Dictionary <int, Coordinate> CoordinateEnemy { get; set; }
    }
}
