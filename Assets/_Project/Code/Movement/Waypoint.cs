using UnityEngine;

namespace SquareDino.RechkinTestTask.Movement
{
    public class Waypoint : MonoBehaviour
    {
        public Vector3 Position => transform.position;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(Position, 0.25f);
        }
#endif
    }
}