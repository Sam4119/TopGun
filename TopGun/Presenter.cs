using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGun
{
    class Presenter
    {
        IView view;
        IModel model;
        public Presenter(IModel model,  IView view)
        {
            this.model = model;
            this.view = view;
            this.view.OnUpdate += ViewModelOnUpdate;//вьюшка обновляет модель через презентер
            //подписываем метод обработчика презентера на событие апдейта view
            //вот это OnUpdate это OnUpdate из IView, а не из модели, он его только запускает.
            this.model.Updated += ModelViewUpdate;//модель обновляет вьюшку через презентер
            //после Update в модели, запускается обработчик презентера и
            //у view срабатывает 
            this.view.MovingPlayer += ViewModelMovingPlayer;
            this.view.Shoot += ViewModelShoot;

        }

        private void ViewModelShoot(object sender, CoordinateEventArgs e)
        {
            model.Shoot(e.MouseX,e.MouseY);// сюда должны приходить координаты игрока
        }

        private void ViewModelMovingPlayer(object sender, DirectionEventArgs e)
        {
            model.MovePlayer(dir:e.Direction);
            
        }

        private void ModelViewUpdate(object sender, OutputCoordinate e)
        {
            view.Render(e.Count,coordPlayer:e.CoordinatePlayer,coordEnemy:e.CoordinateEnemy,e.CoordinateBullet,e.Radius);//
        }

        private void ViewModelOnUpdate(object sender, EventArgs e)
        {
            model.Update();//у модели включаем метод апдейт с помощью презентера
        }
    }
}
