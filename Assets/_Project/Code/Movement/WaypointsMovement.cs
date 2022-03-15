using MyBox;
using UnityEngine;
using UnityEngine.AI;

namespace SquareDino.RechkinTestTask.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class WaypointsMovement : MonoBehaviour
    {
        [SerializeField] [AutoProperty] private NavMeshAgent _navMeshAgent;

        public void MoveTo(Waypoint waypoint) => _navMeshAgent.SetDestination(waypoint.Position);
    }
}