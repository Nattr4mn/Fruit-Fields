using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void Load(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    public void ReloadCurrentLevel()
    {
        print(SceneManager.GetActiveScene().buildIndex);
        Load(SceneManager.GetActiveScene().buildIndex);
    }
}
