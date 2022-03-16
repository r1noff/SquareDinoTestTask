using SquareDino.RechkinTestTask.Movement;
using UnityEngine;
using UnityEngine.Events;

namespace SquareDino.RechkinTestTask.Enemies
{
    public class BattleZone : MonoBehaviour
    {
        public event UnityAction Cleared;

        private const int LineCount = 3;
        private const float Spacing = 1;

        [SerializeField] private EnemyHealth _enemyPrefab;
        [SerializeField] private int _enemiesCount;
        [SerializeField] private Transform _spawnPoint;

        private int _currentEnemiesCount;

        [field: SerializeField] public Waypoint Waypoint { get; private set; }

        private void Start()
        {
            _currentEnemiesCount = _enemiesCount;
            SpawnEnemyBulk();
        }

        private void SpawnEnemyBulk()
        {
            int linesCount = Mathf.CeilToInt(1f * _enemiesCount / LineCount);
            for (var i = 0; i < linesCount; i++)
            {
                for (var j = 0; j < LineCount; j++)
                {
                    if (_currentEnemiesCount >= _enemiesCount) return;
                    Vector3 delta = _spawnPoint.position + new Vector3(j * Spacing, 0, i * Spacing);
                    SpawnEnemy(delta);
                }
            }
        }

        private void SpawnEnemy(Vector3 position)
        {
            EnemyHealth enemy = Instantiate(_enemyPrefab, position, transform.rotation);
            enemy.transform.SetParent(transform);
            enemy.Dead += OnEnemyDead;
        }

        private void OnEnemyDead(EnemyHealth enemy)
        {
            _currentEnemiesCount--;
            enemy.Dead -= OnEnemyDead;
            if (_currentEnemiesCount == 0)
                Cleared?.Invoke();
        }
    }
}