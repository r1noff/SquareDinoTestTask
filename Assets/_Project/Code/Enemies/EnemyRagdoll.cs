using MyBox;
using UnityEngine;

namespace SquareDino.RechkinTestTask.Enemies
{
    public class EnemyRagdoll : MonoBehaviour
    {
        [SerializeField] [AutoProperty] private EnemyHealth _health;
        [SerializeField] [AutoProperty] private Animator _animator;
        [SerializeField] [AutoProperty] private Rigidbody[] _rigidbodies;

        private void Start() =>
            _rigidbodies.ForEach(r => r.isKinematic = true);

        private void OnEnable() =>
            _health.Dead += EnableRagdoll;

        private void OnDisable() =>
            _health.Dead -= EnableRagdoll;

        private void EnableRagdoll(EnemyHealth _)
        {
            _animator.enabled = false;
            _rigidbodies.ForEach(r => r.isKinematic = false);
        }
    }
}