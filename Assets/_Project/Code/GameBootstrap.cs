using SquareDino.RechkinTestTask.GameStates;
using UnityEngine;
using Zenject;

namespace SquareDino.RechkinTestTask
{
    public class GameBootstrap : MonoBehaviour
    {
        private IState[] _states;
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine, IState[] states)
        {
            _stateMachine = stateMachine;
            _states = states;
        }

        private void Start()
        {
            foreach (IState state in _states)
                _stateMachine.AddState(state.GetType(), state);
            _stateMachine.Enter<GameStartState>();
        }
    }
}