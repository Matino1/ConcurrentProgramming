namespace Data
{
    public abstract class DataAPI
    {
        public abstract double getBallPositionX(int ballId);
        public abstract double getBallPositionY(int ballId);
        public abstract int getBallRadius(int ballId);
        public abstract double getBallSpeed(int ballId);
        public abstract void setBallSpeed(int ballId, double newSpeed);
        public abstract void createBalls(int ballsAmount);

        public static DataAPI CreateDataBall()
        {
            return new DataBall();
        }

        private class DataBall : DataAPI
        {
            private BallRepository ballRepository;
            public DataBall()
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

            public override void setBallSpeed(int ballId, double newSpeed)
            {
                this.ballRepository.getBall(ballId).Speed = newSpeed;
            }

            public override void createBalls(int ballsAmount)
            {
                ballRepository.CreateBalls(ballsAmount);
            }
        }
    }
}