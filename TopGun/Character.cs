﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    class Character
    {
        private Coordinate _position ;
       
        private Collider _hitBox ;
        private int _ammo;
        private int _hp;
        public Bullet Shoot(Coordinate ShotDir)
        {
            Bullet b = new Bullet(5,5,new Coordinate (ShotDir.X,ShotDir.Y));
            return b;
        }
        public void InitProperties(int x, int y, int hp,int armor)
        {
            _position = new Coordinate(x, y);
            _hp = hp;
            _ammo = armor;
            _hitBox = new Collider(10, _position);
        }
        
        public Coordinate Position
        {
            get
            {
                return _position;
            }
            set
            { 
                _position = value; 
            }
        }
        //public void ChangeProperties(Coordinate coordinate, int hp,int ammo)
        //{
        //    _position = coordinate;
        //}
        public void MovePlayer(int dir)
        {
            switch (dir)
            {

                case 1:
                    {
                        _position.X += 2;
                        break;
                    }
                case 2:
                    {
                        _position.X -= 2;
                        break;
                    }
                case 3:
                    {
                        _position.Y += 2;
                        break;
                    }
                case 4:
                    {
                        _position.Y -= 2;
                        break;
                    }
            }

        }
    }

}
