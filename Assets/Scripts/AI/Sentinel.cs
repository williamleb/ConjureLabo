using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Game
{

    public class Sentinel : MonoBehaviour
    {
        private enum State
        {
            Patrolling,
            Running,
            Cursing
        }

        [SerializeField] private SentinelObserver sentinelObserver;
        [SerializeField] private CurseEventChannel curseEventChannel;
        
        [SerializeField] private Curse curse;

        [SerializeField] private Transform[] spawnPoints;
        [Tooltip("Position where the Sentinel will be teleported when cursing. This position should not be visible by the player in game.")]
        [SerializeField] private Transform cursePosition;
        
        private WaypointPatrol waypointPatrol;
        private Run run;
        private NavMeshAgent navMeshAgent;
        private AudioSource screamAudioSource;
        
        private State state;

        private void Awake()
        {
            waypointPatrol = GetComponent<WaypointPatrol>();
            run = GetComponent<Run>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            screamAudioSource = GetComponent<AudioSource>();

            state = State.Patrolling;
        }

        private void OnEnable()
        {
            sentinelObserver.OnPlayerSeen += TransitionToRunning;
            curse.OnCursedSensor += TransitionToCursing;
            curseEventChannel.OnCurseFinished += TransitionToPatrolling;
        }

        private void OnDisable()
        {
            sentinelObserver.OnPlayerSeen -= TransitionToRunning;
            curse.OnCursedSensor -= TransitionToCursing;
            curseEventChannel.OnCurseFinished -= TransitionToPatrolling;
        }
        
        private void Start()
        {
            TransitionToPatrolling();
        }

        private void TransitionToRunning()
        {
            screamAudioSource.Play();
            state = State.Running;
            UpdateBehaviour();
        }
        
        private void TransitionToCursing()
        {
            navMeshAgent.Warp(cursePosition.position);

            state = State.Cursing;
            UpdateBehaviour();
        }

        private void TransitionToPatrolling()
        {
            navMeshAgent.Warp(spawnPoints[Random.Range(0, spawnPoints.Length)].position);
            waypointPatrol.ShuffleWaypointsOrder();
            
            state = State.Patrolling;
            UpdateBehaviour();
        }

        private void UpdateBehaviour()
        {
            switch (state)
            {
                case State.Patrolling:
                    waypointPatrol.enabled = true;
                    run.enabled = false;
                    curse.enabled = false;
                    break;
                case State.Running:
                    waypointPatrol.enabled = false;
                    run.enabled = true;
                    curse.enabled = true;
                    break;
                default: // State.Cursing
                    waypointPatrol.enabled = false;
                    run.enabled = false;
                break;
            }
        }
    }
}