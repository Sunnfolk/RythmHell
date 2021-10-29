using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Menu_World
{
    public class SceneController : MonoBehaviour
    {
        public GameObject credits;
        public GameObject controls;

        //public GameObject text;
        //public GameObject crossButton;
        public PauseMenu pauseMenu;
        private bool m_CreditsIsActive;
        private bool m_ControlsIsActive;

        private void Update()
        {
            if (!Keyboard.current.escapeKey.wasPressedThisFrame) return;
            if (m_CreditsIsActive)
            {
                ShowCredits();
            }else if (m_ControlsIsActive)
            {
                ShowControls();
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

        public void ShowControls()
        {
            if (controls == null) return;
            if (m_ControlsIsActive)
            {
                controls.SetActive(false);
                m_ControlsIsActive = false;
            }
            else
            {
                controls.SetActive(true);
                m_ControlsIsActive = true;
            }
        }

        public void ShowCredits()
        {
            if (credits == null) return;
            if (m_CreditsIsActive)
            {
                //text.SetActive(false);
                //crossButton.SetActive(false);
                credits.SetActive(false);
                m_CreditsIsActive = false;
            }
            else
            {
                credits.SetActive(true);
                //crossButton.SetActive(true);
                m_CreditsIsActive = true;
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
            if (m_CreditsIsActive)
            {
                ShowCredits();
            }
            else
            {
                ShowControls();
            }
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