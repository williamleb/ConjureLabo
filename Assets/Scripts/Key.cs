using System;
using UnityEngine;

namespace Game
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private GameObject keyVisual;

        private bool isPicked;

        private CollectibleHover collectibleHover;
        private AudioSource audioSource;

        private void Awake()
        {
            isPicked = false;

            collectibleHover = GetComponent<CollectibleHover>();
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isPicked)
            {
                var keyHolder = other.GetComponent<KeyHolder>();

                if (keyHolder != null)
                {
                    keyHolder.GiveKey();
                    
                    keyVisual.SetActive(false);
                    audioSource.Play();
                    isPicked = true;
                }
            }
        }

        public void Reset()
        {
            isPicked = false;
            keyVisual.SetActive(true);
            
            collectibleHover.ResetCenter();
        }
    }
}