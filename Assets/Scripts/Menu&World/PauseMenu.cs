using Notes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Menu_World
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused;
        public GameObject pauseMenuUI;
        public AudioSource music;

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
            music.Play();
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            music.Pause();
            GameIsPaused = true;
        }
    }
}