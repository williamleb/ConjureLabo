using System;
using UnityEngine;

namespace Game
{
    public class FinalDoor : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var keyHolder = other.GetComponent<KeyHolder>();

            if (keyHolder != null && keyHolder.HasKey)
            {
                Open();
                
                keyHolder.RemoveKey();
            }
        }

        private void Open()
        {
            animator.SetTrigger(FinalDoorAnimatorParameters.Open);
        }
    }
}