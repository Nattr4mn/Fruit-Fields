using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    public event UnityAction FruitCollected
    {
        add => _event.AddListener(value);
        remove => _event.AddListener(value);
    }

    [SerializeField] private Animator _animator;
    private Player _player;
    private UnityEvent _event = new UnityEvent();

    public void Initialized(Player player)
    {
        _player = player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _player.gameObject)
        {
            _animator.SetTrigger("clap");
            _event.Invoke();
        }
    }

    private void Hidden()
    {
        gameObject.SetActive(false);
    }
}
