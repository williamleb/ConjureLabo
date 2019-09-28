using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PlayerMovementTutorial : MonoBehaviour
    {
        [SerializeField] private List<Selectable> uiElements;

        [SerializeField] private Sprite movementTutorialSprite;
        [SerializeField] private Sprite returnToMenuTutorialSprite;

        [SerializeField] private SpeechBubble speechBubble;
        
        private PlayerMovement playerMovement;

        private bool tutorialIsActive;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();

            tutorialIsActive = false;
        }

        private void Start()
        {
            playerMovement.enabled = false;
        }

        private void Update()
        {
            if (tutorialIsActive)
            {
                if (playerMovement.IsWalking)
                {
                    speechBubble.Hide();
                }
                else if (!speechBubble.IsShowed)
                {
                    speechBubble.Show(returnToMenuTutorialSprite);
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TerminateTutorial();
                }
            }
        }

        private void DisableUiElements()
        {
            foreach (var uiElement in uiElements)
            {
                uiElement.interactable = false;
            }
        }

        private void EnableUiElements()
        {
            foreach (var uiElement in uiElements)
            {
                uiElement.interactable = true;
            }
            
            uiElements[0].Select();
        }

        public void StartTutorial()
        {
            DisableUiElements();
            playerMovement.enabled = true;
            speechBubble.Show(movementTutorialSprite);
            tutorialIsActive = true;
        }

        private void TerminateTutorial()
        {
            EnableUiElements();
            playerMovement.enabled = false;
            speechBubble.Hide();
            tutorialIsActive = false;
        }
    }
}