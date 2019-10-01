using System;
using UnityEngine;

namespace Game
{
    public class InvisiblePadSensor : MonoBehaviour
    {
        private MaterialSwapper materialSwapper;

        private void Awake()
        {
            materialSwapper = GetComponent<MaterialSwapper>();
        }

        public void OnInvisiblePadEntered()
        {
            materialSwapper.SwapWithCurrent();
            
            // TODO
        }

        public void OnInvisiblePadLeft()
        {
            materialSwapper.RevertSwap();
            
            // TODO
        }
    }
}