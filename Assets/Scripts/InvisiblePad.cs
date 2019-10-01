using System;
using UnityEngine;

namespace Game
{
    public class InvisiblePad : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<InvisiblePadSensor>()?.OnInvisiblePadEntered();
        }

        private void OnTriggerExit(Collider other)
        {
            other.GetComponent<InvisiblePadSensor>()?.OnInvisiblePadLeft();
        }
    }
}