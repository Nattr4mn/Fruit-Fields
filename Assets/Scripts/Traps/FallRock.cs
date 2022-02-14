using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRock : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _rock;
    [SerializeField] private GameObject _destroyedRock;
    [SerializeField] private float _timeToDestroy;

    private void Start()
    {
        _rock.SetActive(true);
        _destroyedRock.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            player.Kill();
            DestroyRock();
        }
        else
        {
            DestroyRock();
            StartCoroutine(RockOff());
        }
    }

    private void DestroyRock()
    {
        _destroyedRock.transform.position = _rock.transform.position;
        _rock.SetActive(false);
        _destroyedRock.SetActive(true);
        _collider.enabled = false;
        _rigidbody.bodyType = RigidbodyType2D.Static;
    }


    private IEnumerator RockOff()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        var progress = _destroyedRock.transform.localScale.x;
        _destroyedRock.SetActive(false);
    }
}
