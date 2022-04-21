using Logic;
using System.Collections.Generic;

namespace Model
{
    public abstract class ModelAPI
    {
        public abstract List<BallInModel> Balls { get; }
        public abstract void AddBallsAndStart(int ballsAmount);

        public static ModelAPI CreateApi()
        {
            return new ModelBall();
        }

        internal class ModelBall : ModelAPI
        {
            private LogicAPI logicApi;
            public override List<BallInModel> Balls => ChangeBallToBallInModel();

            public ModelBall()
            {
                logicApi = logicApi ?? LogicAPI.CreateLayer();
            }

            public override void AddBallsAndStart(int ballsAmount)
            {
                logicApi.AddBalls(ballsAmount);
                logicApi.StartMovingBalls();
            }

            public List<BallInModel> ChangeBallToBallInModel()
            {
                List<BallInModel> result = new List<BallInModel>();

                foreach (Ball ball in logicApi.GetBalls())
                {
                    result.Add(new BallInModel(ball));
                }
                return result;
            }
        }

    }
}