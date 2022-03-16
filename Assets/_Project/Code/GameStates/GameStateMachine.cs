using System;
using System.Collections.Generic;

namespace SquareDino.RechkinTestTask.GameStates
{
    public class GameStateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _currentState;

        public void AddState(Type stateType, IState state) =>
            _states.Add(stateType, state);

        public void Enter<TState>() where TState : class, IState
        {
            _currentState?.Exit();
            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}