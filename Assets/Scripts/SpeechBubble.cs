﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SpeechBubble : MonoBehaviour
    {
        [SerializeField] private Image speechImage;
        [SerializeField] private CanvasGroup speechBubbleCanvasGroup;
        
        [SerializeField] private float showingSpeed = 5f;
        [SerializeField] private float hidingSpeed = 10f;
        
        [SerializeField] private bool startsHidden = true;
        
        [SerializeField] private Transform positionToFollow;

        private Vector3 offset;

        private bool isShowing;
        private bool isHiding;

        private void Awake()
        {
            offset = transform.position - positionToFollow.position;

            isShowing = false;
            isHiding = false;
        }

        private void Start()
        {
            if (startsHidden)
            {
                speechBubbleCanvasGroup.alpha = 0f;
            }
            else
            {
                speechBubbleCanvasGroup.alpha = 1f;
            }
        }

        private void Update()
        {
            transform.position = positionToFollow.position + offset;

            if (isShowing)
            {
                AdjustScaleUp();
            }
            else if (isHiding)
            {
                AdjustScaleDown();
            }
        }

        private void AdjustScaleUp()
        {
            // If we finished scaling our speech bubble up...
            if (Math.Abs(transform.localScale.x - 1f) < 0.1f)
            {
                isShowing = false;
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                var localScale = transform.localScale;
                
                localScale += new Vector3(showingSpeed, showingSpeed, showingSpeed) * Time.deltaTime;
                localScale = Vector3.Min(localScale, new Vector3(1f, 1f, 1f));
                
                transform.localScale = localScale;
            }
        }

        private void AdjustScaleDown()
        {
            // If we finished scaling our speech bubble down...
            if (Math.Abs(transform.localScale.x) < 0.1f)
            {
                isHiding = false;
                speechBubbleCanvasGroup.alpha = 0f;
                transform.localScale = new Vector3(0f, 0f, 0f);
            }
            else
            {
                var localScale = transform.localScale;
                
                localScale -= new Vector3(hidingSpeed, hidingSpeed, hidingSpeed) * Time.deltaTime;
                localScale = Vector3.Max(localScale, new Vector3(0f, 0f, 0f));
                
                transform.localScale = localScale;
            }
        }

        public void Show(Sprite spriteToSay)
        {
            isShowing = true;
            isHiding = false;

            speechBubbleCanvasGroup.alpha = 1f;
            speechImage.sprite = spriteToSay;

            transform.localScale = new Vector3(0f, 0f, 0f);
        }

        public void Hide()
        {
            isHiding = true;
            isShowing = false;
            
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}