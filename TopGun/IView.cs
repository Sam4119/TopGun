using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    public interface IView
    {
        event EventHandler Shoot;
        event EventHandler OnUpdate;
        event EventHandler <DirectionEventArgs> MovingPlayer;
        void Render(Coordinate coordPlayer, Dictionary<int,Coordinate> coordEnemy);
    }

    public class DirectionEventArgs
    {
        public int Direction { get; set; }
    }
}
