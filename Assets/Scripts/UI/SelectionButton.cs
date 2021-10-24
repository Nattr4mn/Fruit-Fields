using TMPro;
using UnityEngine;

[RequireComponent(typeof(LoadLevel))]
public class SelectionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private LoadLevel _loadLevel;
    private int _levelIndex;

    public void Initialized(string buttonText, int levelIndex)
    {
        _text.text = buttonText;
        _levelIndex = levelIndex;
    }

    public void StartLevel()
    {
        _loadLevel.Load(_levelIndex);
    }

}
