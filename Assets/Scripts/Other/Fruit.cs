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
    private UnityEvent _event = new UnityEvent();
    private bool _isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _animator.SetTrigger("clap");
            if(!_isCollected)
            {
                _isCollected = true;
                _event.Invoke();
            }
        }
    }

    private void Hidden()
    {
        gameObject.SetActive(false);
    }
}
