using System;
using UnityEngine;

namespace Game
{
    public class KeyHolder : MonoBehaviour
    {
        [SerializeField] private GameObject heldKey;
        
        private bool hasKey;

        public bool HasKey => hasKey;

        private void Awake()
        {
            hasKey = false;
        }

        public void GiveKey()
        {
            hasKey = true;
            
            heldKey.SetActive(true);
        }

        public void RemoveKey()
        {
            hasKey = false;
            
            heldKey.SetActive(false);
        }
    }
}