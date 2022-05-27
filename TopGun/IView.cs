using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    public interface IView
    {
        event EventHandler <CoordinateEventArgs> Shoot;//<ShootEventArgs >
        event EventHandler OnUpdate;
        event EventHandler <DirectionEventArgs> MovingPlayer;
        void Render(Coordinate coordPlayer, Dictionary<int,Coordinate> coordEnemy, List <(Coordinate, int ,int )> coordBullet, int radius);
        //изменить в соответствии со списком в модели
    }

    public class CoordinateEventArgs
    {
        public int MouseX { get; set; }
        public int MouseY { get; set; }
    }

    //public class ShootEventArgs
    //{
    //    public Coordinate dir { get; set; }
    //}
    public class DirectionEventArgs
    {
        public int Direction { get; set; }
    }
}
