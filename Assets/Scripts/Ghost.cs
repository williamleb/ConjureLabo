using System;
using UnityEngine;

namespace Game
{
    public class Ghost : MonoBehaviour
    {
        private WaypointPatrol waypointPatrol;
        private Investigation investigation;
        
        private bool isInvestigating;

        private void Awake()
        {
            waypointPatrol = GetComponent<WaypointPatrol>();
            investigation = GetComponent<Investigation>();

            isInvestigating = false;
        }

        private void OnEnable()
        {
            investigation.OnInvestigationRequest += StartInvestigation;
            investigation.OnInvestigationFinished += StopInvestigation;
        }

        private void OnDisable()
        {
            investigation.OnInvestigationRequest -= StartInvestigation;
            investigation.OnInvestigationFinished -= StopInvestigation;
        }

        private void Start()
        {
            UpdateBehaviour();
        }

        private void UpdateBehaviour()
        {
            waypointPatrol.enabled = !isInvestigating;
            investigation.enabled = isInvestigating;
        }

        private void StartInvestigation()
        {
            isInvestigating = true;
            UpdateBehaviour();
        }

        private void StopInvestigation()
        {
            isInvestigating = false;
            UpdateBehaviour();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                investigation.RequestInvestigation(new Vector3(-18, 0, -1));
            }
        }
    }
}