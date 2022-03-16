using SquareDino.RechkinTestTask.Enemies;
using SquareDino.RechkinTestTask.Movement;
using UnityEngine.SceneManagement;

namespace SquareDino.RechkinTestTask.GameStates
{
    public class GameLoopState : IState
    {
        private readonly WaypointsMovement _playerMovement;
        private readonly BattleZone[] _battleZones;
        private readonly Waypoint _finalWaypoint;

        private int _currentZoneIndex;

        private BattleZone CurrentZone => _battleZones[_currentZoneIndex];

        public GameLoopState(WaypointsMovement playerMovement, BattleZone[] battleZones, Waypoint finalWaypoint)
        {
            _playerMovement = playerMovement;
            _battleZones = battleZones;
            _finalWaypoint = finalWaypoint;
        }

        public void Enter() =>
            SendToCurrentZone();

        public void Exit() { }

        private void SendToCurrentZone()
        {
            if (_currentZoneIndex >= _battleZones.Length)
            {
                _playerMovement.MoveTo(_finalWaypoint);
                _playerMovement.Came += FinishGame;
            }
            else
            {
                _playerMovement.MoveTo(CurrentZone.Waypoint);
                CurrentZone.Cleared += OnZoneCleared;
            }
        }

        private void FinishGame()
        {
            _playerMovement.Came -= FinishGame;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnZoneCleared()
        {
            CurrentZone.Cleared -= OnZoneCleared;
            _currentZoneIndex++;
            SendToCurrentZone();
        }
    }
}