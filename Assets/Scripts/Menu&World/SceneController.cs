using Menu_World;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}