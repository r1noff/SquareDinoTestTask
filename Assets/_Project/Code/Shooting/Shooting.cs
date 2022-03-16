using System;
using SquareDino.RechkinTestTask.Input;
using SquareDino.RechkinTestTask.ObjectPool;
using UnityEngine;
using Zenject;

namespace SquareDino.RechkinTestTask.Shooting
{
    public class Shooting : MonoBehaviour
    {
        private ClickHandler _clickHandler;
        private IObjectPool<Projectile> _pool;

        [Inject]
        private void Construct(IObjectPool<Projectile> pool, ClickHandler clickHandler)
        {
            _pool = pool;
            _clickHandler = clickHandler;
        }

        private void OnEnable() => 
            _clickHandler.Clicked += OnClicked;
        
        private void OnDisable() => 
            _clickHandler.Clicked -= OnClicked;


        private void OnClicked(Vector3 worldPosition)
        {
            Projectile projectile = _pool.GetObject();
            Vector3 position = transform.position;
            Vector3 direction = worldPosition - position;
            projectile.Emit(position, direction);
        }
    }
}