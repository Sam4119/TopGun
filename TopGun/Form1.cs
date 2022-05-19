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
        Presenter p;
        Coordinate BuferPos;
        Dictionary<int, Coordinate> EnemyPos;
        public Form1()
        {
            InitializeComponent();
            p = new Presenter(new Model(),this);
            tmrFPS.Interval = 17;
            tmrFPS.Start();
        }

        public event EventHandler Shoot = delegate { };
        public event EventHandler OnUpdate = delegate { };
        public event EventHandler <DirectionEventArgs> MovingPlayer;


        public void Render(Coordinate coordPlayer, Dictionary<int, Coordinate> coordEnemy)
        {
            EnemyPos = coordEnemy;
            BuferPos = coordPlayer;
            this.Refresh();
        }
        private void PaintGame(object sender,PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            SolidBrush enemyBrosh = new SolidBrush(Color.Red);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            if(BuferPos!=null)
            {
                g.FillRectangle(solidBrush, BuferPos.X, BuferPos.Y, 50, 50);
            }
            if(EnemyPos!= null)
            {
                foreach(var r in EnemyPos)
                {
                    g.FillRectangle(enemyBrosh,r.Value.X, r.Value.Y, 50, 50);
                }
                
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
    }
}
