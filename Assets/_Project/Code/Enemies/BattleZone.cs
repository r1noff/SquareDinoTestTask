using System;
using MyBox;
using SquareDino.RechkinTestTask.Movement;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace SquareDino.RechkinTestTask.Enemies
{
    public class BattleZone : MonoBehaviour
    {
        public event UnityAction Cleared;

        private const int LineCount = 3;
        private const float Spacing = 1;

        [SerializeField ]private EnemyHealth _enemyPrefab;
        [SerializeField] private int _enemiesCount;
        [SerializeField] private Transform _spawnPoint;

        [field: SerializeField] public Waypoint Waypoint { get; private set; }

        private int _currentEnemiesCount;
        
        private void Start()
        {
            _currentEnemiesCount = _enemiesCount;
            SpawnEnemyBulk();
        }

        private void SpawnEnemyBulk()
        {
            int linesCount = _enemiesCount / LineCount;
            for (var i = 0; i < linesCount; i++)
            {
                for (var j = 0; j < LineCount; j++)
                {
                    Vector3 delta = _spawnPoint.position + new Vector3(j * Spacing, 0, i * Spacing);
                    SpawnEnemy(delta);
                }
            }
        }

        private void SpawnEnemy(Vector3 position)
        {
            EnemyHealth enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
            enemy.Dead += OnEnemyDead;
        }

        private void OnEnemyDead()
        {
            _currentEnemiesCount--;
            if(_currentEnemiesCount == 0)
                Cleared?.Invoke();
        }
    }
}