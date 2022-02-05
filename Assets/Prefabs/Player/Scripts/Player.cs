using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TossableObject))]
public class Player : MonoBehaviour
{
    public PlayerHealth Health => _playerHealth;
    public PlayerMovement Movement => _playerMovement;
    public PlayerJump Jump => _playerJump;
    public TossableObject Tossable => _tossableObject;
    public Rigidbody2D Rigidbody => _rigidbody;

    private PlayerMovement _playerMovement;
    private PlayerJump _playerJump;
    private PlayerHealth _playerHealth;
    private TossableObject _tossableObject;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerJump = GetComponent<PlayerJump>();
        _tossableObject = GetComponent<TossableObject>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (!TryLoadSkin())
            throw new Exception("Failed to load skin!");
    }

    private bool TryLoadSkin()
    {
        foreach (Transform child in transform)
        {
            if(child.TryGetComponent(out SkinLoader skinLoader))
            {
                skinLoader.LoadSkin();
                GetComponent<Animator>().runtimeAnimatorController = skinLoader.CurrentSkin.SkinObject.GetComponent<Animator>().runtimeAnimatorController;
                GetComponent<SpriteRenderer>().sprite = skinLoader.CurrentSkin.SkinObject.GetComponent<SpriteRenderer>().sprite;
                return true;
            }
        }

        return false;
    }
}
