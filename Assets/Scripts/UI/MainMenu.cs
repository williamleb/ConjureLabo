using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Slider volumeSlider;

        private void Start()
        {
            volumeSlider.value = AudioListener.volume;
        }

        public void Play()
        {
            SceneManager.LoadScene(Scenes.MainScene);
        }

        public void ShowControls()
        {
            
        }

        public void ExitGame()
        {
            Application.Quit();
            
            #if UNITY_EDITOR
                Debug.Log("Quitting the application...");
            #endif
        }

        public void ChangeVolume()
        {
            AudioListener.volume = volumeSlider.value;
        }
    }
}