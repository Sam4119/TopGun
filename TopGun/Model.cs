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
        private Collider _collider;
        private int _id = 0;
        private List<Bullet> _bufBullet = new List<Bullet>();
        private Random _random = new Random();
        public event EventHandler <OutputCoordinate> Updated = delegate { };
        
        public void MovePlayer(int dir)
        {
            _player.MovePlayer(dir);
        }
        public void Shoot(int MouseX, int MouseY)//передай данные отсюда
        {
            double pX = MouseX - _player.Position.X;
            double pY = MouseY - _player.Position.Y;
            double Module = Math.Sqrt(pX * pX + pY * pY);
            double MX = pX / (Module);
            double MY = pY / (Module);
            _bufBullet.Add(_player.Shoot(MX,MY));
        }
        public void BulletMove()
        {
            foreach (var b in _bufBullet)
            {
                b.Position.X += b.SpeedX;
                b.Position.Y += b.SpeedY;
            }
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

            for (int i = 0; i <= 1; i++)
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
            if(_bufBullet!=null)
            {
                BulletMove();
            }
            
            _bufCoords.Clear();//дубляж кода и update и moveplayer отрисовывает
            foreach (var c in _enemys)
            {
                _bufCoords.Add(c.Key, c.Value.Position);
            }
            List<(Coordinate pos, int r,int d)> BulletPropeties = new List<(Coordinate pos , int r ,int d)>();
            
            foreach (var bb in _bufBullet)
            {
                BulletPropeties.Add((bb.Position,bb.HitBox.Radius,bb.Damage));
            }
            foreach(var b in BulletPropeties)
            {
                Coordinate c = b.pos;
                int R = b.r;
                int d = b.d;
            }
            List<Bullet> deleteBullet = new List<Bullet>();
            List<int> deleteEnemys = new List<int>();
            foreach (var CB in _bufBullet)
            {
                foreach(var CE in _enemys)
                {
                    if(CB.HitBox.IsCollided(CE.Value.HitBox.Radius, CE.Value.Position.X, CE.Value.Position.Y))
                    {
                        deleteBullet.Add(CB);
                        deleteEnemys.Add(CE.Key);
                    }
                }

            }
            foreach(var DB in deleteBullet)
            {
                _bufBullet.Remove(DB);
            }
            foreach(var ED in deleteEnemys)
            {
                _enemys.Remove(ED);
            }

            Updated.Invoke(this, new OutputCoordinate()
            {
                CoordinatePlayer = _player.Position,
                CoordinateEnemy = _bufCoords,
                CoordinateBullet = BulletPropeties,// поправить это

                Radius = 5
            });// _bufBullet.HitBox.Radius});//метод update активирует Updated IModel
        }

    }
}
