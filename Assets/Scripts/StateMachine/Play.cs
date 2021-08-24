namespace PingPong
{
    public class Play : State
    {
        private Level _level;

        public Play(Level level)
        {
            _level = level;
        }

        public override void Enter()
        {
            _level.Play();
        }

        public override void Exit()
        {
            _level.Stop();
        }
    }
}
