using Notes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Menu_World
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused;
        public GameObject pauseMenuUI;
        public SystemInput inputSystem;

        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
}