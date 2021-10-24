using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
}
