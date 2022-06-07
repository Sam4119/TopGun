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
        private int _countBullet;
        private int _id = 0;
        private List<Bullet> _bufBullet = new List<Bullet>();
        private Random _random = new Random();
        public event EventHandler<OutputCoordinate> Updated = delegate { };

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
            _countBullet++;
            _bufBullet.Add(_player.Shoot(MX, MY));
            if (_countBullet == 10)
            {
                
            }//здесь сейчас хародкод, переделать под кол-во патронов в разном оружии
        }
        //public void BulletMove()
        //{
        //    foreach (var b in _bufBullet)
        //    {
        //        b.Position.X += b.SpeedX;
        //        b.Position.Y += b.SpeedY;
        //    }
        //}
        public void CreatEnemy(int cX, int cY, int hp, int armor)
        {
            Character enemy = new Character();
            enemy.InitProperties(cX, cY, hp, armor);
            _enemys.Add(_id, enemy);
            _id++;
        }
        public void CreatePlayer()
        {
            _player = new Character();
            _player.InitProperties(10, 10, 25, 10);
        }
        public Model()
        {
            CreatePlayer();

            for (int i = 0; i <= 4; i++)
            {
                int enemyX = _random.Next(10, 1000);
                int enemyY = _random.Next(10, 700);
                int enemyHealth = _random.Next(10, 25);
                int enemyArmor = _random.Next(1, 10);
                CreatEnemy(enemyX, enemyY, enemyHealth, enemyArmor);
            }
            //CreatEnemy(250, 250, 50, 10);
            //Bullet nb = new Bullet(1, 0, 10, 5, new Coordinate(0, 245));
            //_bufBullet.Add(nb);
        }
        public void Update()
        {
            if (_bufBullet != null)
            {
                foreach (var bullet in _bufBullet)
                {
                    bullet.MoveBullet(bullet.Position.X + bullet.SpeedX, bullet.Position.Y + bullet.SpeedY);
                }
            }

            _bufCoords.Clear();
            foreach (var c in _enemys)
            {
                //_bufCoords.Add(//c.Key, c.Value.Position);
                _bufCoords.Add(c.Key, c.Value.HitBox.Position);
            }
            List<(Coordinate pos, double r, int d)> BulletPropeties = new List<(Coordinate pos, double r, int d)>();

            foreach (var bb in _bufBullet)
            {
                //BulletPropeties.Add((bb.Position, bb.HitBox.Radius, bb.Damage));
                BulletPropeties.Add((bb.HitBox.Position, bb.HitBox.Radius, bb.Damage));
            }
            foreach (var b in BulletPropeties)
            {
                Coordinate c = b.pos;
                double R = b.r;
                int d = b.d;
            }
            List<Bullet> deleteBullet = new List<Bullet>();
            List<int> deleteEnemys = new List<int>();
            foreach (var CB in _bufBullet)
            {
                foreach (var CE in _enemys)
                {
                    if (CB.HitBox.IsCollided(CE.Value.HitBox.Radius, CE.Value.HitBox.Position.X, CE.Value.HitBox.Position.Y))
                    {
                        deleteBullet.Add(CB);
                        deleteEnemys.Add(CE.Key);
                    }
                }

            }
            foreach (var DB in deleteBullet)
            {
                _bufBullet.Remove(DB);
            }
            foreach (var ED in deleteEnemys)
            {
                _enemys.Remove(ED);
            }

            int count = _enemys.Count();
            Updated.Invoke(this, new OutputCoordinate()
            {
                Count = count,
                CoordinatePlayer = _player.Position,
                CoordinateEnemy = _bufCoords,
                CoordinateBullet = BulletPropeties,// поправить это
                Radius = 5
            });// _bufBullet.HitBox.Radius});//метод update активирует Updated IModel
        }

    }
}
