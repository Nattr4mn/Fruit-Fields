using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _enemyRigidbody;
    [SerializeField] private Collider2D _enemyCollider;
    [SerializeField] private Collider2D _killableCollider;

    public void Kill(Player player)
    {
        player.Tossable.Toss();
        _animator.SetTrigger("hit");
        _killableCollider.enabled = false;
        _enemy.enabled = false;
        _enemyCollider.enabled = false;
        _enemyRigidbody.bodyType = RigidbodyType2D.Dynamic;
        _enemyRigidbody.velocity += Vector2.up * 20f;
        _enemyRigidbody.gravityScale = 5f;
        StartCoroutine(DestroyByTime());
    }

    private IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(5f);
        _enemy.gameObject.SetActive(false);
    }
}
