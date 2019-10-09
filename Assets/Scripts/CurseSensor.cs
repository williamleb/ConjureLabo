using System;
using UnityEngine;

namespace Game
{
    public class CurseSensor : MonoBehaviour
    {
        [SerializeField] private CurseEventChannel curseEventChannel;

        [SerializeField] private GameObject curseVisual;

        private InvisiblePadSensor invisiblePadSensor;
        private bool isCursed;

        private void Awake()
        {
            invisiblePadSensor = GetComponent<InvisiblePadSensor>();
            
            isCursed = false;
        }

        private void Start()
        {
            UpdateCurseVisual();
        }

        private void Update()
        {
            if (isCursed)
            {
                curseEventChannel.PublishNewCursePosition(transform.position);

                if (invisiblePadSensor.IsInvisible)
                {
                    StopCurse();
                }
            }
        }

        public void OnCurseStarted()
        {
            isCursed = true;
            curseEventChannel.PublishCurseStarted();
            
            UpdateCurseVisual();
        }

        private void StopCurse()
        {
            isCursed = false;
            curseEventChannel.PublishCurseFinished();
            
            UpdateCurseVisual();
        }

        private void UpdateCurseVisual()
        {
            curseVisual.SetActive(isCursed);
        }
    }
}