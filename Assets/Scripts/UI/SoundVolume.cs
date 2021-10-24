using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _effects;

    private void Start()
    {
        _gameData = Save.Instance.GameData;
        _music.volume = _gameData.MusicVolume;
        _effects.volume = _gameData.SoundEffectVolume;
    }

    public void MusicVolumeChange(float value)
    {
        _music.volume = value;
        _gameData.MusicVolume = value;
    }

    public void EffectsVolumeChange(float value)
    {
        _effects.volume = value;
        _gameData.SoundEffectVolume = value;
    }
}
