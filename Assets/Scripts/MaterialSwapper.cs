using System;
using UnityEngine;

namespace Game
{
    public class MaterialSwapper : MonoBehaviour
    {
        [SerializeField] private Material[] invisibleMaterials;
        [SerializeField] private Renderer objectRenderer;

        private Material[] savedMaterial;

        private void Awake()
        {
            savedMaterial = objectRenderer.materials;
        }

        public void SwapWithCurrent()
        {
            savedMaterial = objectRenderer.materials;
            objectRenderer.materials = invisibleMaterials;
        }

        public void RevertSwap()
        {
            objectRenderer.materials = savedMaterial;
        }
    }
}