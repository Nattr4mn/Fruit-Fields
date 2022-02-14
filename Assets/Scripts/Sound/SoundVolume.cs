using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private AudioSource _uiSound;
    [SerializeField] private AudioSource _effects;

    private void Start()
    {
        _gameData = Save.Instance.GameData;
        _uiSound.volume = _gameData.UISoundVolume;
        _effects.volume = _gameData.SoundEffectVolume;
    }

    public void EffectsVolumeChange(float value)
    {
        _effects.volume = value;
        _gameData.SoundEffectVolume = value;
    }

    public void UIVolumeChange(float value)
    {
        _uiSound.volume = value;
        _gameData.UISoundVolume = value;
    }
}
