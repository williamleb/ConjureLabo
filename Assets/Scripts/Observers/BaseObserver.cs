using UnityEngine;

namespace Game
{
    public class BaseObserver : MonoBehaviour
    {
        [SerializeField] private Transform player;

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

        protected bool IsPlayerInSight()
        {
            var playerIsInSight = false;

            if (isPlayerInRange)
            {
                var position = transform.position;
                var direction = player.position - position + Vector3.up;
                var ray = new Ray(position, direction);


                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit))
                {
                    // First condition: the player is not behind an object.
                    if (raycastHit.collider.transform == player)
                    {
                        // Second condition: the player is not stepping on an invisible pad.
                        var invisiblePadSensor = raycastHit.collider.GetComponent<InvisiblePadSensor>();
                        if (!invisiblePadSensor || (invisiblePadSensor && !invisiblePadSensor.IsInvisible))
                        {
                            playerIsInSight = true;
                        }
                    }
                }
            }
            
            return playerIsInSight;
        }
    }
}