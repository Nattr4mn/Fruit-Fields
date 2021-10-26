using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource _soundEffectSource;
    [SerializeField] private AudioClip _soundEffectClip;
    private GameObject _door;
    private bool _canOpen = false;

    private void Start()
    {
        _door = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if(player.Keys > 0)
            {
                _canOpen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _canOpen = false;
        }
    }

    public void OpenDoor()
    {
        if(_canOpen)
        {
            _soundEffectSource.PlayOneShot(_soundEffectClip);
            _door.SetActive(false);
        }
    }
}
