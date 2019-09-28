using Parameters;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float displayImageDuration = 1f;
    
    [SerializeField] private GameObject player;
    
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private CanvasGroup caughtBackgroundImageCanvasGroup;

    [SerializeField] private AudioSource exitAudio;
    [SerializeField] private AudioSource caughtAudio;
    
    private bool isPlayerAtExit;
    private bool isPlayerCaught;

    private bool hasAudioPlayed;
    
    private float timer;

    private void Awake()
    {
        isPlayerAtExit = false;
        isPlayerCaught = false;
        hasAudioPlayed = false;
        
        timer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, exitAudio, false);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, caughtAudio, true);
        }
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, AudioSource audioSource, bool restartLevel)
    {
        if (!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed = true;
        }
        
        timer += Time.deltaTime;
        imageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if (restartLevel)
            {
                SceneManager.LoadScene(Scenes.MainScene);
            }
            else
            {
                Application.Quit();
            }
        }
    }
    
    public void CaughtPlayer ()
    {
        isPlayerCaught = true;
    }

}
