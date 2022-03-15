using System;
using MyBox;
using UnityEngine;
using UnityEngine.Events;

namespace SquareDino.RechkinTestTask.Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        public event UnityAction Dead;

        public event UnityAction ValueChanged;

        [field: SerializeField] public int MaxValue { get; private set; }

        public int Value { get; private set; }

        public void TakeDamage(int damage)
        {
            Value -= damage;
            ValueChanged?.Invoke();
            if(Value <= 0)
                Dead?.Invoke();
        }
        
        private void Start() => 
            Value = MaxValue;

        [ButtonMethod]
        private void Kill() =>
            TakeDamage(Value);
    }
}