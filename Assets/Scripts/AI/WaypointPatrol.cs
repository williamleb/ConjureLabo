using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class WaypointPatrol : MonoBehaviour
    {
        [SerializeField] private Transform[] waypoints;

        private int currentWaypointIndex;
        
        private NavMeshAgent navMeshAgent;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();

            currentWaypointIndex = 0;
        }

        private void OnEnable()
        {
            UpdateNavMeshAgentDestination();
        }

        private void Update()
        {
            if (HasReachedDestination())
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                UpdateNavMeshAgentDestination();
            }
        }

        private bool HasReachedDestination()
        {
            // If the remaining distance to the destination is exactly 0, it means the nav mesh didn't have time to
            // compute it yet, hence why it cannot have reached its destination.'.
            if (navMeshAgent.remainingDistance == 0f) return false;

            return navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance;
        }

        private void UpdateNavMeshAgentDestination()
        {
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }

        public void ShuffleWaypointsOrder()
        {
            waypoints.Shuffle();
        }
    }
}