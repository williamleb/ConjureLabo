using System;
using UnityEngine;

namespace Game
{
    public delegate void CurseEventHandler();
    
    public class Curse : MonoBehaviour
    {
        public event CurseEventHandler OnCursedSensor;
        
        private Collider curseCollider;

        private void Awake()
        {
            curseCollider = GetComponent<Collider>();
        }

        private void Start()
        {
            curseCollider.enabled = enabled;
        }

        private void OnEnable()
        {
            curseCollider.enabled = true;
        }

        private void OnDisable()
        {
            curseCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            var curseSensor = other.GetComponent<CurseSensor>();

            if (curseSensor)
            {
                curseSensor.OnCurseStarted();
                OnCursedSensor?.Invoke();
            }
        }
    }
}