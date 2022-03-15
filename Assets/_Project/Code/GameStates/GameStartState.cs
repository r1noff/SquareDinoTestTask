using SquareDino.RechkinTestTask.Input;
using UnityEngine;

namespace SquareDino.RechkinTestTask.GameStates
{
    public class GameStartState : IState
    {
        private readonly ClickHandler _clickHandler;
        private readonly IStateMachine _stateMachine;

        public GameStartState(ClickHandler clickHandler, IStateMachine stateMachine)
        {
            _clickHandler = clickHandler;
            _stateMachine = stateMachine;
        }

        public void Enter() =>
            _clickHandler.Clicked += OnClicked;

        public void Exit() => 
            _clickHandler.Clicked -= OnClicked;

        private void OnClicked(Vector3 position) => 
            _stateMachine.Enter<GameLoopState>();
    }
}