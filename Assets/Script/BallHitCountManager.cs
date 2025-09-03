namespace Script
{
    public class BallHitCountManager
    {
        private static int ballHitCount;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            ballHitCount = 0;
        }

        public static void AddBallHitCount(int count)
        {
            ballHitCount += count;
        }
    }
}