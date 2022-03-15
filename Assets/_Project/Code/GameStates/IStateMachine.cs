using System;

namespace SquareDino.RechkinTestTask.GameStates
{
    public interface IStateMachine
    {
        void AddState(Type stateType, IState state);

        void Enter<TState>() where TState : class, IState;
    }
}