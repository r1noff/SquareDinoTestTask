using DG.Tweening;
using SquareDino.RechkinTestTask.Enemies;
using SquareDino.RechkinTestTask.ObjectPool;
using UnityEngine;

namespace SquareDino.RechkinTestTask.Shooting
{
    public class Projectile : MonoBehaviour, IPooledObject
    {
        private const float MaxDistance = 30f;

        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _pushForce;

        private Vector3 _direction;

        public void Emit(Vector3 origin, Vector3 direction)
        {
            _direction = direction;
            transform.position = origin;
            transform
                .DOMove(transform.position + direction.normalized * _speed, MaxDistance / _speed)
                .OnComplete(ReturnToPool);
        }

        public bool IsFree() => !gameObject.activeInHierarchy;

        public void ReturnToPool()
        {
            transform.DOKill();
            gameObject.SetActive(false);
        }

        public void Take() => gameObject.SetActive(true);

        private void OnTriggerEnter(Collider other)
        {
            var health = other.gameObject.GetComponentInParent<EnemyHealth>();
            if (health != null)
                health.TakeDamage(_damage);
            if (other.gameObject.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddForce(_direction.normalized * _pushForce);
            ReturnToPool();
        }
    }
}