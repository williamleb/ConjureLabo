using System;
using UnityEngine;

namespace Game
{
    public class FinalDoor : MonoBehaviour
    {
        [SerializeField] private Sprite keySprite;
        [SerializeField] private SpeechBubble speechBubble;
        
        [SerializeField] private AudioSource unlockAudioSource;
        [SerializeField] private AudioSource squeekAudioSource;
        
        private Animator animator;

        private bool isOpened;

        private void Awake()
        {
            isOpened = false;
            
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var keyHolder = other.GetComponent<KeyHolder>();

            if (keyHolder != null)
            {
                if (keyHolder.HasKey)
                {
                    Open();
                
                    keyHolder.RemoveKey();
                }
                else if (!speechBubble.IsShowed)
                {
                    speechBubble.Show(keySprite);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<KeyHolder>() != null)
            {
                speechBubble.Hide();
            }
        }

        private void Open()
        {
            if (!isOpened)
            {
                animator.SetTrigger(FinalDoorAnimatorParameters.Open);
                unlockAudioSource.Play();
                squeekAudioSource.Play();
                isOpened = true;
            }
        }
    }
}