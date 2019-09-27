using System;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
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

        private void Start()
        {
            UpdateNavMeshAgentDestination();
        }

        private void Update()
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                UpdateNavMeshAgentDestination();
            }
        }

        private void UpdateNavMeshAgentDestination()
        {
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}