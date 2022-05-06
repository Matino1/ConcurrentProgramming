using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public abstract class LogicAPI
    {
        public abstract void StartMovingBalls();
        public abstract void AddBalls(int BallsAmount);

        public abstract List<Ball> GetBalls();

        public static LogicAPI CreateLayer(DataAPI data = default(DataAPI))
        {
            return new BusinessLogic(data == null ? DataAPI.CreateDataBall() : data);
        }

        private class BusinessLogic : LogicAPI
        {
            private readonly DataAPI dataAPI;
            private Task BoardTask;
            private Board board;

            public BusinessLogic(DataAPI dataAPI)
            {
                this.dataAPI = dataAPI;
                board = new Board(530);
            }

            public override void StartMovingBalls()
            {
                if (board.Balls.Count > 0)
                {
                    BoardTask = Task.Run(board.MoveBallsInLoop);
                }
            }

            public override void AddBalls(int ballsAmount)
            {
                board.AddBalls(ballsAmount);
            }

            public override List<Ball> GetBalls()
            {
                return board.Balls;
            }
        }

    }
}
