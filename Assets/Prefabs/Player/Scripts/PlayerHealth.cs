using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TossableObject))]
public class PlayerHealth : MonoBehaviour
{
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public UnityEvent HpChange;

    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    private Animator _animator;
    private TossableObject _tossableObject;
    private bool _isDamaged = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _tossableObject = GetComponent<TossableObject>();
        _currentHealth = _maxHealth;
    }

    public void HealthChange(int healthPoints)
    {
        if (healthPoints > 0 && _currentHealth < _maxHealth)
        {
            _currentHealth += healthPoints;
        }
        else if (healthPoints < 0 && _currentHealth > 0 && !_isDamaged)
        {
            _animator.SetTrigger("hit");
            _currentHealth += healthPoints;
            _tossableObject.Toss();
            StartCoroutine(Damaged());
            Handheld.Vibrate();
            if (_currentHealth <= 0)
                Kill();
        }
        HpChange.Invoke();
    } 

    private IEnumerator Damaged()
    {
        _isDamaged = true;
        AnimatorClipInfo[] clipInfo = _animator.GetCurrentAnimatorClipInfo(0);

        if (clipInfo != null)
        {
            AnimationClip clip = clipInfo[0].clip;
            print(clip.length);
            yield return new WaitForSeconds(clip.length);
        }
        else
        {
            Debug.LogError("Unable to get information about the clip!");
        }

        _isDamaged = false;
    }

    public void Kill()
    {
        LoadLevel loadLevel = new LoadLevel();
        loadLevel.ReloadCurrentLevel();
    }
}
