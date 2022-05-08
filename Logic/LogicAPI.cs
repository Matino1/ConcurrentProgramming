using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Data;

namespace Logic
{
    public abstract class LogicAPI : IObserver<int>
    {
        public abstract void StartMovingBalls();
        public abstract void AddBalls(int BallsAmount);
        public abstract double getBallPositionX(int ballId);
        public abstract double getBallPositionY(int ballId);
        public abstract int getBallRadius(int ballId);

        public abstract void OnCompleted();
        public abstract void OnError(Exception error);
        public abstract void OnNext(int value);


        public static LogicAPI CreateLayer(DataAbstractAPI data = default(DataAbstractAPI))
        {
            return new BusinessLogic(data == null ? DataAbstractAPI.CreateDataApi() : data);
        }

        private class BusinessLogic : LogicAPI
        {
            private readonly DataAbstractAPI dataAPI;
            private IDisposable unsubscriber;
            static object _lock = new object();
            //private CollisionControler collisionControler;

            public BusinessLogic(DataAbstractAPI dataAPI)
            {
                this.dataAPI = dataAPI;
                Subscribe(dataAPI);
            }

            public override double getBallPositionX(int ballId)
            {
                return this.dataAPI.getBallPositionX(ballId);
            }

            public override double getBallPositionY(int ballId)
            {
                return this.dataAPI.getBallPositionY(ballId);
            }

            public override int getBallRadius(int ballId)
            {
                return this.dataAPI.getBallRadius(ballId);
            }


            public override void AddBalls(int BallsAmount)
            {
                dataAPI.createBalls(20);
            }

            public override void StartMovingBalls()
            {
                dataAPI.createBalls(20);
            }

            #region observer

            public virtual void Subscribe(IObservable<int> provider)
            {
                if (provider != null)
                    unsubscriber = provider.Subscribe(this);
            }

            public override void OnCompleted()
            {
                throw new NotImplementedException();
            }

            public override void OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            public override void OnNext(int value)
            {
              /*       Monitor.Enter(_lock);
                try
                {

                    new System.Threading.Thread(() =>
                    {*/
                        System.Diagnostics.Debug.WriteLine("Collision check: Ball: " + value);

                        for (int i = 1; i <= 20; i++)
                        {
                            if (value != i)
                            {
                                if (CollisionControler.IsCollision(dataAPI.getBallPositionX(value), dataAPI.getBallPositionY(value), dataAPI.getBallPositionX(i), dataAPI.getBallPositionY(i), dataAPI.getBallRadius(value), dataAPI.getBallRadius(i)))
                                {
                                    //double temp = dataAPI.getBallSpeed(value);
                                    //dataAPI.setBallSpeed(value, -dataAPI.getBallSpeed(i));
                                    //dataAPI.setBallSpeed(i, -temp);
                                    dataAPI.setBallSpeed(value, -dataAPI.getBallSpeed(i));
                                    dataAPI.setBallSpeed(i, -dataAPI.getBallSpeed(value));
                                }
                            }
                        }
             /*       }).Start();

                }
                catch (SynchronizationLockException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                finally
                {
                    // Releasing object
                    Monitor.Exit(_lock);
                    //Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId} Released");
                }*/


                    
            }

            public virtual void Unsubscribe()
            {
                unsubscriber.Dispose();
            }

            #endregion

        }
    }
}