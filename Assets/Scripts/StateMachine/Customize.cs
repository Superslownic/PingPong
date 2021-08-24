namespace PingPong
{
    public class Customize : State
    {
        private SkinSelectorModel _skinSelector;

        public Customize(SkinSelectorModel skinSelector)
        {
            _skinSelector = skinSelector;
        }

        public override void Enter()
        {
            _skinSelector.Open();
        }

        public override void Exit()
        {
            _skinSelector.Close();
        }
    }
}
