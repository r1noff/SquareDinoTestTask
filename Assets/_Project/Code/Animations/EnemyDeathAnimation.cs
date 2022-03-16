using MyBox;
using SquareDino.RechkinTestTask.Enemies;
using UnityEngine;

namespace SquareDino.RechkinTestTask.Animations
{
    public class EnemyDeathAnimation : MonoBehaviour
    {
        [SerializeField] private Material _deathMaterial;
        
        [SerializeField] [AutoProperty] private Renderer[] _renderers;
        [SerializeField] [AutoProperty] private EnemyHealth _health;

        private void OnEnable() => 
            _health.Dead += OnDead;
        
        private void OnDisable() => 
            _health.Dead -= OnDead;

        private void OnDead(EnemyHealth _) => 
            _renderers.ForEach(r => r.material = _deathMaterial);
    }
}