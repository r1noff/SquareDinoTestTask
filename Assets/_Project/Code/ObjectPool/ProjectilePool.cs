using System.Collections.Generic;
using SquareDino.RechkinTestTask.Shooting;
using UnityEngine;
using Zenject;

namespace SquareDino.RechkinTestTask.ObjectPool
{
    public class ProjectilePool : MonoBehaviour, IObjectPool<Projectile>
    {
        private readonly List<Projectile> _objects = new List<Projectile>();
        
        private Projectile _prefab;

        [Inject]
        private void Construct(Projectile prefab) => 
            _prefab = prefab;

        public Projectile GetObject()
        {
            foreach (Projectile pooledObject in _objects)
                if (pooledObject.IsFree())
                {
                    pooledObject.Take();
                    return pooledObject;
                }
            Projectile newObject = Instantiate(_prefab, transform);
            _objects.Add(newObject);
            return newObject;
        }
    }
}