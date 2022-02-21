using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(TossableObject))]
[RequireComponent(typeof(PlayerCamera))]
public class Player : MonoBehaviour
{
    public event Action PlayerDead;
    private PlayerMovement _playerMovement;
    private PlayerJump _playerJump;
    private TossableObject _tossableObject;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private PlayerCamera _playerCamera;
    private InterstititalAds _interstititalAds;
    private bool _isDead = false;
    [SerializeField] private AudioSource _soundEffect;
    [SerializeField] private AudioClip _hitSound;

    public bool IsDead => _isDead;
    public PlayerMovement Movement => _playerMovement;
    public PlayerJump Jump => _playerJump;
    public TossableObject Tossable => _tossableObject;
    public Rigidbody2D Rigidbody => _rigidbody;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerJump = GetComponent<PlayerJump>();
        _tossableObject = GetComponent<TossableObject>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _playerCamera = GetComponent<PlayerCamera>();
        _interstititalAds = FindObjectOfType<InterstititalAds>();

        _playerMovement.Init(_animator, _rigidbody);
        _playerJump.Init(_animator, _rigidbody);
        _playerCamera.Init();

        if (!TryLoadSkin())
            throw new Exception("Failed to load skin!");
    }

    private void FixedUpdate()
    {
        _playerMovement.TryMove();
        _playerCamera.TryCameraMove(transform.position);
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

    public void Kill()
    {
        if(!_isDead)
        {
            _isDead = true;
            _soundEffect.PlayOneShot(_hitSound);
            _playerMovement.IsStoped = true;
            _playerJump.LockJump = true;
            _tossableObject.Toss();
            _animator.SetTrigger("death");
            CalculateDeath();
            StartCoroutine(KillTimeOut());
        }
    }

    private void CalculateDeath()
    {
        PlayerPrefs.SetInt("DeadCount", PlayerPrefs.GetInt("DeadCount") + 1);
        if (PlayerPrefs.GetInt("DeadCount") == 3)
        {
            _interstititalAds.Show();
            PlayerPrefs.SetInt("DeadCount", 0);
        }
    }

    private IEnumerator KillTimeOut()
    {
        yield return new WaitForSeconds(0.25f);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        yield return new WaitForSeconds(0.5f);
        LoadLevel loadLevel = new LoadLevel();
        loadLevel.ReloadCurrentLevel();
    }
}
