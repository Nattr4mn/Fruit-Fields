using UnityEngine;

public class Character : MonoBehaviour
{
    public string CharacterName => _characterName;
    public Animator CharacterAnimator => _characterAnimator;

    [SerializeField] private string _characterName;
    [SerializeField] private Animator _characterAnimator;
}
