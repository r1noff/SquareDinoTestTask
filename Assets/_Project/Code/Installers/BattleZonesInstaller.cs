using SquareDino.RechkinTestTask.Movement;
using UnityEngine;
using Zenject;

namespace SquareDino.RechkinTestTask.Installers
{
    public class BattleZonesInstaller : MonoInstaller
    {
        [SerializeField] private Waypoint[] _waypoints;

        public override void InstallBindings() => 
            Container.BindInstance(_waypoints);
    }
}