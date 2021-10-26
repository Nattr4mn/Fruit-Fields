using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private AudioSource _soundEffectSource;
    [SerializeField] private AudioClip _soundEffectClip;
    [SerializeField] private Animator _keyAnimator;
    private GameObject _key;


    private void Start()
    {
        _key = gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _soundEffectSource.PlayOneShot(_soundEffectClip);
            _keyAnimator.SetTrigger("clap");
            player.AddKey();
            _key.SetActive(false);
        }
    }
}
