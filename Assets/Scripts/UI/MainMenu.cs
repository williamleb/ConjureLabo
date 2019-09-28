using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class MainMenu : MonoBehaviour
    {
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
    }
}