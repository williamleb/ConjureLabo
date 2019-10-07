using System;
using UnityEngine;

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

        [SerializeField] private SentinelObserver sentinelObserver; // Know when the player is spotted
        [SerializeField] private Curse curse; // Activate/deactivate when 
        [SerializeField] private CurseEventChannel curseEventChannel; // Know when the curse was finished.
        
        [SerializeField] private Vector3 cursePosition; // Position to put when cursing
        
        private WaypointPatrol waypointPatrol;
        private Run run;
        
        private State state;

        private void Awake()
        {
            waypointPatrol = GetComponent<WaypointPatrol>();
            run = GetComponent<Run>();

            state = State.Patrolling;
        }

        private void OnEnable()
        {
            sentinelObserver.OnPlayerSeen += StartRunning;
            // Curse.onCurse...
            curseEventChannel.OnCurseFinished += Respawn;
        }

        private void OnDisable()
        {
            sentinelObserver.OnPlayerSeen -= StartRunning;
            // Curse.onCurse...
            curseEventChannel.OnCurseFinished -= Respawn;
        }

        private void StartRunning()
        {
            // TODO Enable run and curse and update speed
        }

        private void Respawn()
        {
            // TODO Return to a random spot and reset speed and enable patrol
        }

        private void Start()
        {
            UpdateBehaviour();
        }

        private void UpdateBehaviour()
        {
            switch (state)
            {
                case State.Patrolling:
                    break; // TODO Enable/disable right behaviours
                case State.Running:
                    break; // TODO Enable/disable right behaviours
                default:
                    // TODO Curse
                break;
            }
        }
    }
}