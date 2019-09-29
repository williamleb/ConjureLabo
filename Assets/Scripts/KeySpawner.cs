using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class KeySpawner : MonoBehaviour
    {
        [SerializeField] private Key key;
        
        private List<Transform> keyspots;

        private void Awake()
        {
            keyspots = new List<Transform>();
            
            foreach (var keyspot in transform)
            {
                keyspots.Add((Transform) keyspot);
            }
        }

        private void Start()
        {
            SpawnKey();
        }

        private void SpawnKey()
        {
            var keyspotIndex = Random.Range(0, keyspots.Count);

            key.transform.position = keyspots[keyspotIndex].position;
            
            key.Reset();
        }
    }
}