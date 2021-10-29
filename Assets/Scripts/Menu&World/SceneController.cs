using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Menu_World
{
    public class SceneController : MonoBehaviour
    {
        public GameObject credits;
        //public GameObject text;
        public GameObject crossButton;
        public PauseMenu pauseMenu;
        private bool m_IsActive;

        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame && m_IsActive)
            {
                ShowCredits();
            }
        }

        public void LoadScene(string scene)
        {
            Resume();
            SceneManager.LoadScene(scene);
        }

        public void ReloadScene()
        {
            Resume();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ShowCredits()
        {
            if (credits == null) return;
            if (m_IsActive)
            {
                //text.SetActive(false);
                crossButton.SetActive(false);
                credits.SetActive(false);
                m_IsActive = false;
            }
            else
            {
                credits.SetActive(true);
                crossButton.SetActive(true);
                m_IsActive = true;
                //StartCoroutine(nameof(Timer));
            }
        }
        
        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public void CrossPress()
        {
           ShowCredits(); 
        }
        private void Resume()
        {
            if (pauseMenu == null) return;
            if (PauseMenu.GameIsPaused)
            {
                pauseMenu.Resume();
            }
        }

        /*private IEnumerator Timer()
        {
            if (!m_IsActive) yield break;
            text.SetActive(true);
            yield return new WaitForSeconds(1);
            text.SetActive(false);
            yield return new WaitForSeconds(1);
            StartCoroutine(nameof(Timer));
        }*/
    }
}