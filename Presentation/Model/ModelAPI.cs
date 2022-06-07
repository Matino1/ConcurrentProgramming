using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;

namespace Model
{
    public interface IBall : INotifyPropertyChanged
    {
        double Top { get; }
        double Left { get; }
        int Diameter { get; }
    }

    public class BallChaneEventArgs : EventArgs
    {
        public IBall Ball { get; set; }
    }

    public abstract class ModelAPI : IObservable<IBall>
    {
        public static ModelAPI CreateApi()
        {
            return new ModelBall();
        }

        public abstract void AddBallsAndStart(int ballsAmount);

        #region IObservable

        public abstract IDisposable Subscribe(IObserver<IBall> observer);

        #endregion IObservable

        internal class ModelBall : ModelAPI
        {
            private LogicAPI logicApi;
            public event EventHandler<BallChaneEventArgs> BallChanged;

            private IObservable<EventPattern<BallChaneEventArgs>> eventObservable = null;
            private List<BallInModel> Balls = new List<BallInModel>();
            //private Dictionary<int, BallInModel> Balls = new Dictionary<int, BallInModel>();

            public ModelBall()
            {
                logicApi = logicApi ?? LogicAPI.CreateLayer();
                //IDisposable observer = logicApi.Subscribe(x => Balls[x.Id - 1].Move(x.PositionX, x.PositionY));
                IDisposable observer = logicApi.Subscribe(x => Balls[x.Id - 1].Move(x.PositionX, x.PositionY));
                eventObservable = Observable.FromEventPattern<BallChaneEventArgs>(this, "BallChanged");
            }

            /*private void idk(Data.IBall  ball)
            {
                if(Balls.ContainsKey(ball.Id))
                {
                    Balls[ball.Id].Move(ball.PositionX, ball.PositionY);
                } 
                else
                {
                    BallInModel newBall = new BallInModel(ball.PositionX, ball.PositionY, ball.Radius);
                    ObservableCollection<IBall> tempBalls = new ObservableCollection<IBall>();
                    foreach (var item in Balls)
                    {
                        tempBalls.Add(item.Value);
                    }

                    BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = tempBalls });
                    Balls.Add(ball.Id, newBall);
                    newBall.Move(ball.PositionX, ball.PositionY);
                } 
            }*/

            public override void AddBallsAndStart(int ballsAmount)
            {
                
                for (int i = 1; i <= ballsAmount; i++)
                {
                    BallInModel newBall = new BallInModel(0, 0, 15);
                    Balls.Add(newBall);
                    BallChanged?.Invoke(this, new BallChaneEventArgs() { Ball = newBall });
                }
                logicApi.AddBallsAndStart(ballsAmount);

                //foreach (BallInModel ball in Balls)
                //{
                   
                //}   
            }

            public override IDisposable Subscribe(IObserver<IBall> observer)
            {
                return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
            }
        }
    }
}