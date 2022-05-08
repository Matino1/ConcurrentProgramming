using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Threading;

namespace Logic
{
    internal static class CollisionControler
    {
        public static bool IsCollision(double positionX1, double positionY1, double positionX2, double positionY2, double radious1 , double radious2)
        {
            double distance = Math.Sqrt(Math.Pow(positionX1 - positionX2, 2) + Math.Pow(positionY1 - positionY2, 2));

            if (distance <= radious1 + radious2)
            {
                return true;
            }

            return false;
        }



    }
}
