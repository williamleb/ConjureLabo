using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game
{
    public class ClaustrophobiaEffect : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform sentinel;

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