using SquareDino.RechkinTestTask.Movement;
using UnityEngine;

namespace SquareDino.RechkinTestTask.GameStates
{
    public class GameLoopState : IState
    {
        private readonly WaypointsMovement _playerMovement;
        private readonly Waypoint[] _waypoints;

        public GameLoopState(WaypointsMovement playerMovement, Waypoint[] waypoints)
        {
            _playerMovement = playerMovement;
            _waypoints = waypoints;
        }

        public void Enter() => 
            _playerMovement.MoveTo(_waypoints[1]);

        public void Exit() => 
            throw new System.NotImplementedException();
    }
}