namespace PingPong
{
    public class GlobalStateMachine : Singleton<GlobalStateMachine>, IStateMachine
    {
        private IStateMachine _stateMachine;

        public GlobalStateMachine()
        {
            _stateMachine = new StateMachine();
        }

        public void SetState<T>() where T : State
        {
            _stateMachine.SetState<T>();
        }

        public IStateMachine AddState(State state)
        {
            _stateMachine.AddState(state);
            return this;
        }
    }
}
