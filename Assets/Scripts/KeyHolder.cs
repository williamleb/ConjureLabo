using System;
using UnityEngine;

namespace Game
{
    public class KeyHolder : MonoBehaviour
    {
        private bool hasKey;

        public bool HasKey => hasKey;

        private void Awake()
        {
            hasKey = false;
        }

        public void GiveKey()
        {
            hasKey = true;
        }
    }
}