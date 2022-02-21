using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hiddenObjects;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _window;
    private Player _player;

    private void Awake()
    {
        _window.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        _window.gameObject.SetActive(false);
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        OpenWindow();
    }

    public void OpenWindow()
    {
        if(!_player.IsDead)
        {
            _hiddenObjects.ForEach(obj => obj.SetActive(false));
            _window.SetActive(true);
            _player.gameObject.SetActive(false);
        }
    }

    public void CloseWindow()
    {
        _animator.SetTrigger("disable");
        _hiddenObjects.ForEach(obj => obj.SetActive(true));
        _player.gameObject.SetActive(true);
    }

    public virtual void Hidden()
    {
        _window.SetActive(false);
    }
}
