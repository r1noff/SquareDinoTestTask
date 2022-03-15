using SquareDino.RechkinTestTask.Input;
using SquareDino.RechkinTestTask.Movement;
using UnityEngine;
using Zenject;

namespace SquareDino.RechkinTestTask.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private WaypointsMovement _playerMovement;

        public override void InstallBindings()
        {
            BindClickHandler();
            BindMovement();
        }

        private void BindClickHandler() =>
            Container
                .Bind<ClickHandler>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();

        private void BindMovement() => Container.BindInstance(_playerMovement);
    }
}