using System;
using UnityEngine;

namespace Game
{
    public class Observer : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private GameEnding gameEnding;

        private bool isPlayerInRange;

        private void Awake()
        {
            isPlayerInRange = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform == player)
            {
                isPlayerInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform == player)
            {
                isPlayerInRange = false;
            }
        }

        private void Update()
        {
            if (isPlayerInRange)
            {
                var position = transform.position;
                var direction = player.position - position + Vector3.up;
                var ray = new Ray(position, direction);

                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit))
                {
                    if (raycastHit.collider.transform == player)
                    {
                        var invisiblePadSensor = raycastHit.collider.GetComponent<InvisiblePadSensor>();
                        if (invisiblePadSensor != null && !invisiblePadSensor.IsInvisible)
                        {
                            gameEnding.CaughtPlayer();
                        }
                    }
                }
            }
        }
    }
}