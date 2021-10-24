using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(SkinLoader))]
[RequireComponent(typeof(Jumping))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public PlayerHealth Health => _playerHealth;
    public PlayerMovement PlayerMovement => _playerMovement;
    public Jumping Jumping => _jumping;
    public SkinLoader Skin => _skin;
    public Animator Animator => _animator;
    public SpriteRenderer SkinSprite => _skinSprite;

    private Rigidbody2D _playerRB;
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private Jumping _jumping;
    private PlayerHealth _playerHealth;
    private SkinLoader _skin;
    private SpriteRenderer _skinSprite;

    private void Awake()
    {
        _skin = GetComponent<SkinLoader>();
        _skin.LoadSkin();
        _animator = _skin.CurrentSkin.GetComponent<Animator>(); 
        _skinSprite = _skin.CurrentSkin.GetComponent<SpriteRenderer>();
        _playerRB = GetComponent<Rigidbody2D>();
        _playerHealth = GetComponent<PlayerHealth>();
        _playerMovement = GetComponent<PlayerMovement>();
        _jumping = GetComponent<Jumping>();
        _jumping.Initialized(_animator);
        _playerMovement.Initialized(_animator);
    }
}
