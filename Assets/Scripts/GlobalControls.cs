using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GlobalControls : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(Scenes.MainMenu);
            }
        }
    }
}