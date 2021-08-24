using System;
using System.Collections.Generic;

namespace PingPong
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, State> _states;
        private State _currentState;

        public StateMachine()
        {
            _states = new Dictionary<Type, State>();
        }

        public void SetState<T>() where T : State
        {
            Type key = typeof(T);

            if (_states.ContainsKey(key) == false)
                throw new ArgumentException();

            _currentState?.Exit();
            _currentState = _states[key];
            _currentState.Enter();
        }

        public IStateMachine AddState(State state)
        {
            _states.Add(state.GetType(), state);
            return this;
        }
    }
}
