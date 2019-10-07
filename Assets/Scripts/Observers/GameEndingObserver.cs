using System;
using UnityEngine;

namespace Game
{
    public class GameEndingObserver : BaseObserver
    {
        [SerializeField] private GameEnding gameEnding;

        private void Update()
        {
            if (IsPlayerInSight())
            {
                gameEnding.CaughtPlayer();
            }
        }
    }
}