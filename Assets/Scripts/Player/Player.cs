using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(SkinLoader))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int Keys => _keys;
    public PlayerHealth Health => _playerHealth;
    public PlayerMovement PlayerMovement => _playerMovement;
    public PlayerJump Jump => _playerJump;
    public SkinLoader Skin => _skin;
    public Animator Animator => _animator;
    public SpriteRenderer SkinSprite => _skinSprite;

    private Rigidbody2D _playerRB;
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private PlayerJump _playerJump;
    private PlayerHealth _playerHealth;
    private SkinLoader _skin;
    private SpriteRenderer _skinSprite;
    private int _keys = 0;
    public void AddKey() => _keys++;

    private void Awake()
    {
        _skin = GetComponent<SkinLoader>();
        _skin.LoadSkin();
        _animator = _skin.CurrentSkin.GetComponent<Animator>(); 
        _skinSprite = _skin.CurrentSkin.GetComponent<SpriteRenderer>();
        _playerRB = GetComponent<Rigidbody2D>();
        _playerHealth = GetComponent<PlayerHealth>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerJump = GetComponent<PlayerJump>();
        _playerJump.Initialized(_animator);
        _playerMovement.Initialized(_animator);
    }

}
