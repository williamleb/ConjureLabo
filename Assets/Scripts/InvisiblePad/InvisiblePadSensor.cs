using System;
using UnityEngine;

namespace Game
{
    public class InvisiblePadSensor : MonoBehaviour
    {
        private MaterialSwapper materialSwapper;

        private bool isInvisible;

        public bool IsInvisible => isInvisible;

        private void Awake()
        {
            materialSwapper = GetComponent<MaterialSwapper>();

            isInvisible = false;
        }

        public void OnInvisiblePadEntered()
        {
            materialSwapper.Swap();
            isInvisible = true;
        }

        public void OnInvisiblePadLeft()
        {
            materialSwapper.Swap();
            isInvisible = false;
        }
    }
}