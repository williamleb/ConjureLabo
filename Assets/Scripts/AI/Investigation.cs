using System;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public delegate void InvestigationEventHandler();
    
    public class Investigation : MonoBehaviour
    {
        public event InvestigationEventHandler OnInvestigationRequest;
        public event InvestigationEventHandler OnInvestigationFinished;

        [SerializeField] private CurseEventChannel curseEventChannel;
        
        private NavMeshAgent navMeshAgent;

        private Vector3 investigatingPosition;

        private void Awake()
        {
            investigatingPosition = Vector3.zero;
            navMeshAgent = GetComponent<NavMeshAgent>();
            
            if (curseEventChannel)
            {
                curseEventChannel.OnCursePositionUpdated += RequestInvestigation;
            }
        }

        private void OnDestroy()
        {
            if (curseEventChannel)
            {
                curseEventChannel.OnCursePositionUpdated -= RequestInvestigation;
            }
        }

        private void Update()
        {
            navMeshAgent.SetDestination(investigatingPosition);

            if (CheckIfInvestigationIsFinished())
            { 
                OnInvestigationFinished?.Invoke();
            }
        }
        
        private void RequestInvestigation(Vector3 position)
        {
            investigatingPosition = position;
            OnInvestigationRequest?.Invoke();
        }

        private bool CheckIfInvestigationIsFinished()
        {
            // If the remaining distance to the destination is exactly 0, it means the nav mesh didn't have time to
            // compute it yet, hence why the investigation cannot be finished.
            if (navMeshAgent.remainingDistance == 0f) return false;

            return navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance;

        }
    }
}