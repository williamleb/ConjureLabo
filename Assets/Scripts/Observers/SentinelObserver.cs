using UnityEngine;

namespace Game
{
    public delegate void SentinelObserverEventHandler();
    public class SentinelObserver : BaseObserver
    {
        public event SentinelObserverEventHandler OnPlayerSeen;

        private bool playerIsSeen;

        private bool PlayerIsSeen
        {
            get => playerIsSeen;
            set
            {
                // We only invoke the OnPlayerSeen event if the player wasn't previously seen.
                if (value && !playerIsSeen)
                {
                    OnPlayerSeen?.Invoke();
                }

                playerIsSeen = value;
            }
        }

        private void Update()
        {
            PlayerIsSeen = IsPlayerInSight();
        }
    }
}