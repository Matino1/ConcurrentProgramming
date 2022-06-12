using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    internal struct DiagnosticData
    {
        public int Id;
        public double PositionX;
        public double PositionY;
        public double SpeedX;
        public double SpeedY;

        internal DiagnosticData(int id, double postionX, double positionY, double speedX, double speedY)
        {
            Id = id;
            PositionX = postionX;
            PositionY = positionY;
            SpeedX = speedX;
            SpeedY = speedY;
        }
    }

    public class Ball : IBall
    {
        public int Id { get;}

        public double PositionX { get; private set; }
        public double PositionY { get; private set; }

        public int Radius { get; } = 15;
        public double Mass { get; } = 10;

        public double SpeedX { get; set; }
        public double SpeedY { get; set; }

        public bool isRunning = true;

        internal readonly IList<IObserver<IBall>> observers;
        private Task BallThread;

        internal Logger logger { get; set; }

        public Ball(int id)
        {
            this.Id = id;

            Random random = new Random();
            observers = new List<IObserver<IBall>>();

            this.PositionX = Convert.ToDouble(random.Next(1, 500));
            this.PositionY = Convert.ToDouble(random.Next(1, 500));

            this.SpeedX = random.NextDouble() * (5 - 3) + 3;
            this.SpeedY = random.NextDouble() * (5 - 3) + 3;
        }

        public void StartMoving()
        {
            this.BallThread = new Task(MoveBall);
            BallThread.Start();
        }

        public void MoveBall()
        {
            while(isRunning)
            {
                ChangeBallPosition();
                logger.addToBuffer(new DiagnosticData(Id, PositionX, PositionY, SpeedX, SpeedY));

                foreach (var observer in observers.ToList())
                {
                    if (observer != null)
                    { 
                        observer.OnNext(this);
                    }
                }
                Thread.Sleep(1);
            }
        }

        public void ChangeBallPosition()
        {
            PositionX += SpeedX;
            PositionY += SpeedY;
        }

        #region provider

        public IDisposable Subscribe(IObserver<IBall> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private IList<IObserver<IBall>> _observers;
            private IObserver<IBall> _observer;

            public Unsubscriber
            (IList<IObserver<IBall>> observers, IObserver<IBall> observer)
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
