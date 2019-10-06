using System;
using UnityEngine;

namespace Game
{
    public class InvisiblePad : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var invisiblePadSensor = other.GetComponent<InvisiblePadSensor>();

            if (invisiblePadSensor != null)
            {
                invisiblePadSensor.OnInvisiblePadEntered();
                audioSource.Play();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var invisiblePadSensor = other.GetComponent<InvisiblePadSensor>();
            
            if (invisiblePadSensor != null)
            {
                invisiblePadSensor.OnInvisiblePadLeft();
                audioSource.Play();
            }
        }
    }
}