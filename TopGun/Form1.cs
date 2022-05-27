using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopGun
{
    public partial class Form1 : Form,IView
    {
        private Presenter _p;
        private Coordinate _buferPosPlayer;
        private List<(Coordinate,int , int)> _buferBulletPos;
        private int _r = 0;
        private Dictionary<int, Coordinate> _buferEnemyPos;
        public Form1()
        {
            InitializeComponent();
            _p = new Presenter(new Model(),this);
            tmrFPS.Interval = 17;
            tmrFPS.Start();
        }

        public event EventHandler <CoordinateEventArgs> Shoot = delegate { };
        public event EventHandler OnUpdate = delegate { };
        public event EventHandler <DirectionEventArgs> MovingPlayer;


        public void Render(Coordinate coordPlayer, Dictionary<int, Coordinate> coordEnemy, List<(Coordinate,int,int)> coordBullet,int radius)
        {
            _r = radius;
            _buferBulletPos = coordBullet;
            _buferEnemyPos = coordEnemy;
            _buferPosPlayer = coordPlayer;
            this.Refresh();
        }
        private void PaintGame(object sender,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            SolidBrush bulletBrush = new SolidBrush(Color.Pink);
            SolidBrush enemyBrosh = new SolidBrush(Color.Red);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            if(_buferPosPlayer!=null)
            {
                g.FillRectangle(solidBrush, (float)_buferPosPlayer.X, (float)_buferPosPlayer.Y, 50, 50);
            }
            if(_buferEnemyPos!= null)
            {
                foreach(var r in _buferEnemyPos)
                {
                    g.FillRectangle(enemyBrosh, (float)r.Value.X, (float)r.Value.Y, 50, 50);
                }
            }
            if(_buferBulletPos!=null)
            {
                foreach (var b in _buferBulletPos)
                {
                    {
                        g.FillRectangle(bulletBrush, (float)b.Item1.X, (float)b.Item1.Y, 5, 5);
                    }
                }
                //g.FillRectangle(bulletBrush, BulletPos.X, BulletPos.Y, R, R);
            }
        }

        private void tmrFPS_Tick(object sender, EventArgs e)
        {
            OnUpdate.Invoke(this, new EventArgs());
        }
        private void KeyPressControl(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'a')
            {
                MovingPlayer.Invoke(this, new DirectionEventArgs() { Direction = 2 });
            }
            if(e.KeyChar == 'd')
            {
                MovingPlayer.Invoke(this, new DirectionEventArgs() { Direction = 1 });
            }
            if (e.KeyChar == 's')
            {
                MovingPlayer.Invoke(this, new DirectionEventArgs() { Direction = 3 });
            }
            if (e.KeyChar == 'w')
            {
                MovingPlayer.Invoke(this, new DirectionEventArgs() { Direction = 4 });
            }
        }
        private void MouseClicks(object sender, MouseEventArgs e)
        {
            int MouseX = e.X;
            int MouseY = e.Y;
            Shoot.Invoke(this, new CoordinateEventArgs() { MouseX = e.X, MouseY = e.Y});
        }

        
    }
}
