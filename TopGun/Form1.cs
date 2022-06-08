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
        private int _count;
        private Presenter _p;
        private Coordinate _buferPosPlayer;
       
        private int _r = 0;
        private Dictionary<int, IObject> _objects = new Dictionary<int, IObject>();
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


        public void Render(int Count, Coordinate coordPlayer, Dictionary<int, IObject> InputObject,int radius)
        {
            _count = Count;
            _r = radius;
            
            _objects = InputObject;
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
            foreach (var r in _objects)
            {
                if(r.Value.Type=="Character")
                {
                    g.DrawEllipse(new Pen(Color.Black, 2.0f), (float)r.Value.Position.X - 25, (float)r.Value.Position.Y - 25, 50, 50);
                }
                if(r.Value.Type == "Bullet")
                {
                    g.FillRectangle(bulletBrush, (float)r.Value.Position.X - 2.5f, (float)r.Value.Position.Y - 2.5f, 5, 5);
                }

            }
            lblCount.Text = @"Врагов на карте:" + _count.ToString();
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
