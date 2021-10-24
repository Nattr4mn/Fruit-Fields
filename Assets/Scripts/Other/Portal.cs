using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public UnityEvent Event;

    [SerializeField] private Player _player;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _player.gameObject)
        {
            _animator.SetTrigger("finish");
            StartCoroutine(BlackHole(collision.gameObject));
        }
    }

    private IEnumerator BlackHole(GameObject player)
    {
        var spriteRenderer = _player.SkinSprite;
        float progress = spriteRenderer.color.a;

        _player.PlayerMovement.Direction(Vector3.zero);

        while (progress > 0)
        {
            progress -= 0.01f;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, progress);
            yield return null;
        }
    }

    private void Finish()
    {
        Event?.Invoke();
    }

    private void Hidden()
    {
        gameObject.SetActive(false);
    }
}
