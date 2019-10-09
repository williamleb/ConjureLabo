using System;
using UnityEngine;

namespace Game
{
    public class ClaustrophobiaScreenEffect : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform sentinel;

        [Tooltip("The maximum distance between the player and the sentinel for the effect to show.")]
        [SerializeField] private float maxDistance = 10f;

        private CanvasGroup claustrophobiaCanvasGroup;

        private void Awake()
        {
            claustrophobiaCanvasGroup = GetComponent<CanvasGroup>();
        }

        private void Update()
        {
            var distanceBetweenEntities = (player.position - sentinel.position).magnitude;
            var alpha = 1 - (distanceBetweenEntities / maxDistance);

            claustrophobiaCanvasGroup.alpha = Math.Max(0f, alpha);
        }
    }
}