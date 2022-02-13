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
        Load(SceneManager.GetActiveScene().buildIndex);
    }
}
