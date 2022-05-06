namespace Data
{
    public abstract class DataAbstractAPI
    {
        public abstract double getBallPositionX(int ballId);
        public abstract double getBallPositionY(int ballId);
        public abstract int getBallRadius(int ballId);
        public abstract double getBallSpeed(int ballId);
        public abstract void createBalls(int ballsAmount);

        public static DataAbstractAPI CreateDataApi()
        {
            return new DataApi();
        }

        private class DataApi : DataAbstractAPI
        {
            private BallRepository ballRepository;
            public DataApi()
            {
                this.ballRepository = new BallRepository();
            }

            public override double getBallPositionX(int ballId)
            {
                return this.ballRepository.getBall(ballId).PositionX;
            }

            public override double getBallPositionY(int ballId)
            {
                return this.ballRepository.getBall(ballId).PositionY;
            }

            public override int getBallRadius(int ballId)
            {
                return this.ballRepository.getBall(ballId).Radius;
            }

            public override double getBallSpeed(int ballId)
            {
                return this.ballRepository.getBall(ballId).Speed;
            }

            public override void createBalls(int ballsAmount)
            {
                ballRepository.CreateBalls(ballsAmount);
            }
        }
    }
}