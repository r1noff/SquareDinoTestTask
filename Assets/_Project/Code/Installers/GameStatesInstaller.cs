using SquareDino.RechkinTestTask.GameStates;
using Zenject;

namespace SquareDino.RechkinTestTask.Installers
{
    public class GameStatesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindState<GameStartState>();
            BindState<GameLoopState>();
        }

        private void BindGameStateMachine() =>
            Container
                .Bind<IStateMachine>()
                .To<GameStateMachine>()
                .FromNew()
                .AsSingle();

        private void BindState<TState>() where TState : IState =>
            Container
                .Bind<IState>()
                .To<TState>()
                .FromNew()
                .AsSingle();
    }
}