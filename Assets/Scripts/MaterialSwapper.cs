using UnityEngine;

namespace Game
{
    public class MaterialSwapper : MonoBehaviour
    {
        [SerializeField] private Material[] swapMaterials;
        [SerializeField] private Renderer objectRenderer;

        public void Swap()
        {
            var tempMaterials = objectRenderer.materials; 
            objectRenderer.materials = swapMaterials;
            swapMaterials = tempMaterials;
        }
    }
}