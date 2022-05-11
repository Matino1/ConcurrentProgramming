using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Numerics;

namespace Logic
{
    internal class CollisionControler
    {
        private int ballId;
        private int mass;
        private int radious;
        private Vector2 postionVector;
        private Vector2 velocityVector;

        public CollisionControler(double poitionX, double poitionY, double speedX, double speedY, int radious, int mass, int ballId )
        {
            this.velocityVector = new Vector2(speedX, speedY);
            this.postionVector = new Vector2(poitionX, poitionY);
            this.ballId = ballId;
            this.radious = radious;
            this.mass = mass;
        }

        public static bool IsCollision(double positionX1, double positionY1, double positionX2, double positionY2, double radious1 , double radious2)
        {
            double distance = Math.Sqrt(Math.Pow(positionX1 - positionX2, 2) + Math.Pow(positionY1 - positionY2, 2));

            if (Math.Abs(distance) <= radious1 + radious2)
            {
                return true;
            }

            return false;
        }

        public static bool IsTouchingBoundariesX(double positionX, double speedX, int boardSize)
        {
            double newX = positionX + speedX;
                
            if (newX > boardSize || newX < 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsTouchingBoundariesY(double positionY, double speedY, int boardSize)
        {
            double newY = positionY + speedY;
            if (newY > boardSize || newY < 0)
            {
                return true;
            }
            return false;
        }

        public Vector2 ImpulseSpeed(double positionX, double positionY, double speedX, double speedY, double Othermass) 
        {
            Vector2 velocityOther = new Vector2(speedX, speedY);
            Vector2 positionOther = new Vector2(positionX, positionY);

            Vector2 momentum = projection(velocityVector - velocityOther, positionOther - postionVector);

            momentum.X =  -momentum.X * (float)Othermass;
            momentum.Y =  -momentum.Y * (float)Othermass;

            return velocityVector + momentum * (1/ (float)mass);
        }

        public Vector2 ImpulseSpeedReversed(double positionX, double positionY, double speedX, double speedY, double Othermass)
        {
            Vector2 velocityOther = new Vector2(speedX, speedY);
            Vector2 positionOther = new Vector2(positionX, positionY);

            Vector2 momentum = projection(velocityOther - velocityVector , postionVector - positionOther);

            momentum.X = -momentum.X * (float)mass;
            momentum.Y = -momentum.Y * (float)mass;

            return velocityOther + momentum * (1 / (float)Othermass);
        }

        public Vector2 projection(Vector2 current,Vector2 other)
        {
            return (other * current * other) / (other * other);
        }

        /*        public static bool IsCollision2(int ballsAmount)
                {
                    for()


                    double distance = Math.Sqrt(Math.Pow(positionX1 - positionX2, 2) + Math.Pow(positionY1 - positionY2, 2));

                    if (distance <= radious1 + radious2)
                    {
                        return true;
                    }

                    return false;
                }*/



    }
}
