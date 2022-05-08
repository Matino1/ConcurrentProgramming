using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Model
{

    public class BallInModel
    {

        public double PositionX { get; set; }
        public double PositionY { get; set; }

        public BallInModel(double X, double Y)
        {
            this.PositionX = X;
            this.PositionY = Y;
        }

    }
}
