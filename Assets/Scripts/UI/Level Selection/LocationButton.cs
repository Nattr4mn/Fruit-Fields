using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LocationButton : MonoBehaviour
{
    [SerializeField] private LevelsListWindow _levelListWindow;
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        if (_levelListWindow.FirstLevelInBuild <= Save.Instance.GameData.LastLevel)
            _button.interactable = true;
        else
            _button.interactable = false;
    }
}
