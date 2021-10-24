using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionWindow : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private SelectionButton _buttonTemplate;
    [SerializeField] private string _levelNameTemplate = "Level_";
    private List<GameObject> _buttonsPool = new List<GameObject>();

    private void OnEnable()
    {
        if (_buttonsPool.Count == 0)
        {
            var levelCount = SceneManager.sceneCountInBuildSettings;
            for (int i = 1; i < levelCount; i++)
            {
                var button = Instantiate(_buttonTemplate, _container);
                button.Initialized(i.ToString(), i);
                _buttonsPool.Add(button.gameObject);
            }
        }
        else
        {
            _buttonsPool.ForEach(button => button.SetActive(true));
        }
    }

    private void OnDisable()
    {
        _buttonsPool.ForEach(button => button.SetActive(false));
    }
}
