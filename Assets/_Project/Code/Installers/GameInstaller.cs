using SquareDino.RechkinTestTask.Enemies;
using SquareDino.RechkinTestTask.GameStates;
using SquareDino.RechkinTestTask.Movement;
using UnityEngine;
using Zenject;

namespace SquareDino.RechkinTestTask.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private BattleZone[] _battleZones;
        [SerializeField] private Waypoint _finalWaypoint;

        public override void InstallBindings()
        {
            BindBattleZones();
            BindFinalWaypoint();
            BindGameStateMachine();
            BindState<GameStartState>();
            BindState<GameLoopState>();
        }

        private void BindBattleZones() =>
            Container.BindInstance(_battleZones);

        private void BindFinalWaypoint() =>
            Container.BindInstance(_finalWaypoint);

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