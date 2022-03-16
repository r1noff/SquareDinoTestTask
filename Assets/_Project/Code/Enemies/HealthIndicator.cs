using MyBox;
using UnityEngine;
using UnityEngine.UI;

namespace SquareDino.RechkinTestTask.Enemies
{
    public class HealthIndicator : MonoBehaviour
    {
        [SerializeField] [AutoProperty] private Slider _slider;
        [SerializeField] [AutoProperty] private EnemyHealth _health;

        private void Start()
        {
            _slider.maxValue = _health.MaxValue;
            _slider.value = _health.Value;
        }

        private void OnEnable() =>
            _health.ValueChanged += OnHealthChanged;

        private void OnDisable() =>
            _health.ValueChanged -= OnHealthChanged;
        
        private void OnHealthChanged() => 
            _slider.value = _health.Value;
    }
}