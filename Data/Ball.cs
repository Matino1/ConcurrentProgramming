using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Data
{
    public class Ball : IObservable<int>
    {
        public int Id { get;}

        public double PositionX { get; private set; }
        public double PositionY { get; private set; }

        public int Radius { get; } = 7;
        public double Mass { get;}
        public double Speed { get; set; }

        public double MoveX { get; private set; }
        public double MoveY { get; private set; }

        public int BoardSize { get; private set; } = 530;

        internal readonly IList<IObserver<int>> observers;

        private Thread BallThread;


        public Ball(int id)
        {
            this.Id = id;

            Random random = new Random();

            observers = new List<IObserver<int>>();

            this.PositionX = Convert.ToDouble(random.Next(1, 100));
            this.PositionY = Convert.ToDouble(random.Next(1, 100));

            //this.Radius = random.Next(1,6);
            this.Mass = Convert.ToDouble(random.Next(1, 10)) * 0.1;

            this.Speed = random.NextDouble() * (5- 2) + 2;

            this.MoveX = random.NextDouble();
            this.MoveY = random.NextDouble();
        }

        public void StartMoving()
        {
            this.BallThread = new Thread(MoveBall);
            BallThread.Start();
        }

        public void MoveBall()
        {
            while(true)
            {
                /*double newX = PositionX + MoveX;
                double newY = PositionY + MoveY;

                if (newX > BoardSize || newX < 0)
                {
                    MoveX = -MoveX;
                }

                if (newY > BoardSize || newY < 0)
                {
                    MoveY = -MoveY;
                }

                PositionX += MoveX;
                PositionY += MoveY;*/

                double newX = PositionX + MoveX * Speed;
                double newY = PositionY + MoveY * Speed;

                if (newX > BoardSize || newX < 0)
                {
                    MoveX = -MoveX;
                }

                if (newY > BoardSize || newY < 0)
                {
                    MoveY = -MoveY;
                }

                PositionX += MoveX * Speed;
                PositionY += MoveY * Speed;

                //Inform observers when position change
                //double[] position = { PositionX, PositionY };
                //Point position = new Point(PositionX, PositionY);
                int threadId = Thread.CurrentThread.ManagedThreadId;
                
                //if (observers != null)
                //{
                    foreach (var observer in observers.ToList())
                    {
                        //if (position is null) 
                        //observer.OnError(new NullReferenceException("Position is incorrect"));
                        //else
                        if (observer != null)
                        {
                            System.Diagnostics.Debug.WriteLine("Ball: " + Id + " moved on thread: " + threadId);
                            observer.OnNext(Id);
                        }

                    }
                //}
                

                System.Threading.Thread.Sleep(1);
            }
        }

        #region provider

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private IList<IObserver<int>> _observers;
            private IObserver<int> _observer;

            public Unsubscriber
            (IList<IObserver<int>> observers, IObserver<int> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        #endregion
    }
}
