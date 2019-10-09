using UnityEngine;

namespace Game
{
    public class CurseScreenEffect : MonoBehaviour
    {
        [SerializeField] private CurseEventChannel curseEventChannel;
        [SerializeField] private float fadeSpeed = 10f;

        private CanvasGroup effectCanvasGroup;

        private bool isFading;

        private void Awake()
        {
            effectCanvasGroup = GetComponent<CanvasGroup>();
            isFading = false;
        }

        private void OnEnable()
        {
            curseEventChannel.OnCurseStarted += StartEffect;
        }

        private void OnDisable()
        {
            curseEventChannel.OnCurseStarted -= StartEffect;
        }

        private void StartEffect()
        {
            effectCanvasGroup.alpha = 1;
            isFading = true;
        }

        private void Update()
        {
            if (isFading)
            {
                effectCanvasGroup.alpha -= fadeSpeed * Time.deltaTime;

                // If the effect is finished...
                if (effectCanvasGroup.alpha <= 0f)
                {
                    effectCanvasGroup.alpha = 0f;
                    isFading = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                StartEffect();
            }
        }
    }
}