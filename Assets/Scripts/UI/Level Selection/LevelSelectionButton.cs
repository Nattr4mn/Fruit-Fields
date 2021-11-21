using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LoadLevel))]
[RequireComponent(typeof(Button))]
public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private LoadLevel _loadLevel;
    private Button _button;
    private int _levelIndex;

    private void OnEnable()
    {
        if(_button == null)
            _button = GetComponent<Button>();

        if (_levelIndex <= Save.Instance.GameData.LastLevel)
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    public void Initialized(string buttonText, int levelIndex)
    {
        _text.text = buttonText;
        _levelIndex = levelIndex;

        if (_levelIndex <= Save.Instance.GameData.LastLevel)
            _button.interactable = true;
        else
            _button.interactable = false;
    }

    public void StartLevel()
    {
        _loadLevel.Load(_levelIndex);
    }

}
