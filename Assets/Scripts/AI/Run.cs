using System;
using UnityEngine;
using UnityEngine.AI;

namespace Game
{
    public class Run : MonoBehaviour
    {
        [SerializeField] private float runSpeed;
        [SerializeField] private Transform runToPosition;

        private NavMeshAgent navMeshAgent;
        
        private float savedSpeed;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            savedSpeed = navMeshAgent.speed;
        }

        private void OnEnable()
        {
            savedSpeed = navMeshAgent.speed;
            navMeshAgent.speed = runSpeed;
        }

        private void OnDisable()
        {
            navMeshAgent.speed = savedSpeed;
        }

        private void Update()
        {
            navMeshAgent.destination = runToPosition.position;
        }
    }
}