namespace PingPong
{
    public interface IStateMachine
    {
        void SetState<T>() where T : State;
        IStateMachine AddState(State state);
    }
}
