using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    class Model : IModel
    {
        private Dictionary<int, Character> _enemys = new Dictionary<int, Character>();
        private Character _player;
        private Dictionary<int, Coordinate> _bufCoords = new Dictionary<int, Coordinate>();
        private int _id = 0;
        private Random _random = new Random();
        public event EventHandler <OutputCoordinate> Updated = delegate { };
        
        public void MovePlayer(int dir)
        {
            _player.MovePlayer(dir);
            //_bufCoords.Clear();
            //foreach (var c in _enemys)
            //{
            //    _bufCoords.Add(c.Key, c.Value.Position);
            //}
            ////
            //Updated.Invoke(this, new OutputCoordinate() { CoordinatePlayer = _player.Position, CoordinateEnemy = _bufCoords});
        }
        public void CreatEnemy(int cX,int cY, int hp, int armor)
        {
            Character enemy = new Character();
            enemy.InitProperties(cX, cY,hp,armor);
            _enemys.Add(_id,enemy);
            _id++;
            
        }
        public void CreatePlayer()
        {
            _player = new Character();
            _player.InitProperties(10,10,25,10);
        }
        public Model()
        {
            CreatePlayer();
            for( int i=0; i<=5; i++)
            {
                int enemyX = _random.Next(10, 1000);
                int enemyY = _random.Next(10, 700);
                int enemyHealth = _random.Next(10, 25);
                int enemyArmor = _random.Next(1, 10);
                CreatEnemy(enemyX, enemyY, enemyHealth, enemyArmor);
            }
        }
        public void Update()
        {
            _bufCoords.Clear();//дубляж кода и update и moveplayer отрисовывает
            foreach (var c in _enemys)
            {
                _bufCoords.Add(c.Key, c.Value.Position);
            }
            Updated.Invoke(this,new OutputCoordinate() { CoordinatePlayer = _player.Position, CoordinateEnemy = _bufCoords});//метод update активирует Updated IModel
        }

    }
}
