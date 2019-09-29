using System;
using UnityEngine;

namespace Game
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private GameObject keyVisual;

        private bool isPicked;

        private void Awake()
        {
            isPicked = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isPicked)
            {
                var keyHolder = other.GetComponent<KeyHolder>();

                if (keyHolder != null)
                {
                    keyHolder.GiveKey();
                }

                keyVisual.SetActive(false);
                isPicked = true;
            }
        }
    }
}