using System;
using UnityEngine;

namespace Game
{
    public class CollectibleHover : MonoBehaviour
    {
        [SerializeField] private float rotatingSpeed = 2f;
        [SerializeField] private float verticalSpeed = 0.1f;
        
        [SerializeField] private float maxVerticalDistance = 0.05f;
        
        private bool isGoingDown;
        
        private Vector3 center;

        private void Awake()
        {
            isGoingDown = false;

            center = transform.position;
        }

        private void Update()
        {
            transform.Rotate(new Vector3(0, rotatingSpeed * Time.deltaTime, 0));

            if (isGoingDown)
            {
                transform.position -= new Vector3(0f, verticalSpeed, 0f) * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(0f, verticalSpeed, 0f) * Time.deltaTime;
            }

            if (transform.position.y <= center.y - maxVerticalDistance)
            {
                isGoingDown = false;
            }
            else if (transform.position.y >= center.y + maxVerticalDistance)
            {
                isGoingDown = true;
            }
        }
    }
}