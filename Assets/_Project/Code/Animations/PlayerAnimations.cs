using System;
using MyBox;
using SquareDino.RechkinTestTask.Movement;
using UnityEngine;

namespace SquareDino.RechkinTestTask.Animations
{
    public class PlayerAnimations : MonoBehaviour
    {
        private const string IdleAnimation = "Idle";
        private const string RunAnimation = "Run";
        
        [SerializeField] [AutoProperty] private Animator _animator;
        [SerializeField] [AutoProperty] private WaypointsMovement _waypointsMovement;

        private void OnEnable()
        {
            _waypointsMovement.Moved += OnMoved;
            _waypointsMovement.Came += OnCame;
        }
        
        private void OnDisable()
        {
            _waypointsMovement.Moved -= OnMoved;
            _waypointsMovement.Came -= OnCame;
        }

        private void OnMoved() => 
            _animator.Play(RunAnimation);

        private void OnCame() => 
            _animator.Play(IdleAnimation);
    }
}