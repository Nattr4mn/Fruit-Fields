using System.Collections.Generic;
using UnityEngine;

public class LevelsListWindow : MonoBehaviour
{
    public int FirstLevelInBuild => _firstLevelInBuild;

    [SerializeField] private int _firstLevelInBuild;
    [SerializeField] private int _lastLevelInBuild;
    [SerializeField] private LevelSelectionButton _buttonTemplate;
    [SerializeField] private Transform _container;
    private List<GameObject> _buttonsPool = new List<GameObject>();

    private void OnEnable()
    {
        if (_buttonsPool.Count == 0)
            CreateButtons();
        else
            _buttonsPool.ForEach(button => button.SetActive(true));
    }

    private void OnDisable()
    {
        _buttonsPool.ForEach(button => button.SetActive(false));
    }

    private void CreateButtons()
    {
        int levelCount = 1;
        for (int i = _firstLevelInBuild; i <= _lastLevelInBuild; i++)
        {
            var button = Instantiate(_buttonTemplate, _container);
            button.Initialized(levelCount.ToString(), i);
            _buttonsPool.Add(button.gameObject);
            levelCount++;
        }
    }
}
