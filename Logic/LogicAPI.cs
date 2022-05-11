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
                dataAPI.createBalls(10);   
            }

            public override void StartMovingBalls()
            {
                //dataAPI.createBalls(5);
               
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
                Monitor.Enter(_lock);
                try
                {
                    CollisionControler collisionControler = new CollisionControler(dataAPI.getBallPositionX(value), dataAPI.getBallPositionY(value), dataAPI.getBallSpeedX(value), dataAPI.getBallSpeedY(value), dataAPI.getBallRadius(value), 10, value);
                    
                    for (int i = 1; i <= 10; i++)
                    {
                        if (value != i)
                        {
                            int id = System.Threading.Thread.CurrentThread.ManagedThreadId;
                            if (CollisionControler.IsCollision(dataAPI.getBallPositionX(value), dataAPI.getBallPositionY(value), dataAPI.getBallPositionX(i), dataAPI.getBallPositionY(i), dataAPI.getBallRadius(value), dataAPI.getBallRadius(i)) )
                            {
                                Vector2 newVelocity = collisionControler.ImpulseSpeed(dataAPI.getBallPositionX(i), dataAPI.getBallPositionY(i), dataAPI.getBallSpeedX(i), dataAPI.getBallSpeedY(i), 10);
                                dataAPI.setBallSpeed(value, newVelocity.X, newVelocity.Y);

                                
                                Vector2 newVelocity2 = collisionControler.ImpulseSpeedReversed(dataAPI.getBallPositionX(i), dataAPI.getBallPositionY(i), dataAPI.getBallSpeedX(i), dataAPI.getBallSpeedY(i), 5);
                               
                                dataAPI.setBallSpeed(i, -newVelocity.X, -newVelocity.Y); 
                            } 
                        }          
                    }

                    if (CollisionControler.IsTouchingBoundariesX(dataAPI.getBallPositionX(value), dataAPI.getBallSpeedX(value), dataAPI.getBoardSize()))
                    {
                        dataAPI.setBallSpeed(value, -dataAPI.getBallSpeedX(value), dataAPI.getBallSpeedY(value));
                    }

                    if (CollisionControler.IsTouchingBoundariesY(dataAPI.getBallPositionY(value), dataAPI.getBallSpeedY(value), dataAPI.getBoardSize()))
                    {
                        dataAPI.setBallSpeed(value, dataAPI.getBallSpeedX(value), -dataAPI.getBallSpeedY(value));
                    }
                }

                catch (SynchronizationLockException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                finally
                {
                    Monitor.Exit(_lock);
                }
            }

            public virtual void Unsubscribe()
            {
                unsubscriber.Dispose();
            }

            #endregion

        }
    }
}