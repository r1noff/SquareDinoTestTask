using SquareDino.RechkinTestTask.ObjectPool;
using SquareDino.RechkinTestTask.Shooting;
using UnityEngine;
using Zenject;

namespace SquareDino.RechkinTestTask.Installers
{
    public class ShootingInstaller : MonoInstaller
    {
        [SerializeField] private Projectile _projectile;

        public override void InstallBindings()
        {
            BindObjectPool();
            BindProjectile();
        }

        private void BindObjectPool() =>
            Container
                .Bind<IObjectPool<Projectile>>()
                .To<ProjectilePool>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();

        private void BindProjectile() =>
            Container.BindInstance(_projectile);
    }
}