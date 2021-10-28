using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu_World
{
    public class SceneController : MonoBehaviour
    {
        public PauseMenu PauseMenu;
    
        public void LoadScene(string scene)
        {
            if (PauseMenu != null)
            {
                if (PauseMenu.GameIsPaused)
                {
                    PauseMenu.Resume();
                }
            }
            SceneManager.LoadScene(scene);
        }

        public void ReloadScene()
        {
            if (PauseMenu != null)
            {
                if (PauseMenu.GameIsPaused)
                {
                    PauseMenu.Resume();
                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //print(SceneManager.GetActiveScene().name);
        }

        public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}