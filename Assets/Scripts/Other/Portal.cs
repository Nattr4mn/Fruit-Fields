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
        float progress = player.transform.localScale.x;

        player.Movement.Direction(Vector3.zero);

        while (progress > 0)
        {
            progress -= 0.05f;
            player.Rigidbody.bodyType = RigidbodyType2D.Kinematic;
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, 5f * Time.deltaTime);
            player.transform.localScale = new Vector3(progress, progress, transform.localScale.z);
            yield return null;
        }

        player.gameObject.SetActive(false);
    }

    private void Finish()
    {
        Event?.Invoke();
    }
}
