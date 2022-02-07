using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public UnityEvent Event;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _animator.SetTrigger("finish");
            StartCoroutine(BlackHole(player));
        }
    }

    private void Show(bool value)
    {
        gameObject.SetActive(value);
    }

    private IEnumerator BlackHole(Player player)
    {
        var spriteRenderer = player.GetComponent<SpriteRenderer>();
        float progress = spriteRenderer.color.a;

        player.Movement.Direction(Vector3.zero);

        while (progress > 0)
        {
            progress -= 0.01f;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, progress);
            yield return null;
        }

        player.gameObject.SetActive(false);
    }

    private void Finish()
    {
        Event?.Invoke();
    }
}
