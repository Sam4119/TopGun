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
        private Dictionary<int, IObject> _objects = new Dictionary<int, IObject>();
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
        public void Shoot(int targetX, int targetY)//передай данные отсюда
        {
            double vectoreTargetX = targetX - _player.Position.X;
            double vectorTaretY = targetY - _player.Position.Y;
            double Module = Math.Sqrt(vectoreTargetX * vectoreTargetX + vectorTaretY * vectorTaretY);
            double bulletSpeedX = vectoreTargetX / (Module);
            double bulletSpeedY = vectorTaretY / (Module);
            
            _objects.Add(_id,_player.Shoot(bulletSpeedX, bulletSpeedY));
            _id++;
        }
        public void CreateEnemy(int cX, int cY, int hp, int armor)
        {
            Character enemy = new Character();
            enemy.InitProperties(cX, cY, hp, armor);
            
            _id++;
            _objects.Add(_id, enemy);
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
                CreateEnemy(enemyX, enemyY, enemyHealth, enemyArmor);
            }
        }
        public void Update()
        {
            foreach(var o in _objects.Values)
            {
                o.Update();
            }
            _bufCoords.Clear();
            foreach (var c in _enemys)
            {
                _bufCoords.Add(c.Key, c.Value.HitBox.Position);
            }
            List<(Coordinate pos, double r, int d)> BulletPropeties = new List<(Coordinate pos, double r, int d)>();

            foreach (var bb in _bufBullet)
            {
               
                BulletPropeties.Add((bb.HitBox.Position, bb.HitBox.Radius, bb.Damage));
            }
            foreach (var b in BulletPropeties)
            {
                Coordinate c = b.pos;
                double R = b.r;
                int d = b.d;
            }
            List<int> deleteObjects = new List<int>();
            foreach(var obj1 in _objects)
            {
                foreach(var obj2 in _objects)
                {
                    if(obj1.Key == obj2.Key)
                    {
                        continue;
                    }
                    if(obj1.GetType()==typeof(Bullet))
                    {
                        if(obj2.GetType()==typeof(Character))
                        {
                            var bullet = (Bullet)obj1.Value;
                            var character = (Character)obj2.Value;
                            if (bullet.HitBox.IsCollided(character.HitBox.Radius, character.HitBox.Position.X, character.HitBox.Position.Y))
                            {
                                deleteObjects.Add(obj1.Key);
                                deleteObjects.Add(obj2.Key);
                            }

                        }
                    }
                }
            }
            foreach (var removedObject in deleteObjects)
            {
                _objects.Remove(removedObject);
            }

            //int count = _enemys.Count();
            Updated.Invoke(this, new OutputCoordinate()
            {
               // Count = count,
                CoordinatePlayer = _player.Position,
                Object = _objects,
                Radius = 5
            });// _bufBullet.HitBox.Radius});//метод update активирует Updated IModel
        }

    }
}
