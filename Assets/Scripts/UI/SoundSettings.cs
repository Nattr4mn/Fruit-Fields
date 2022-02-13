using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private Slider _UISoundSlider;

    private void OnEnable()
    {
        var gameData = Save.Instance.GameData;
        _musicSlider.value = gameData.MusicVolume;
        _effectsSlider.value = gameData.SoundEffectVolume;
        _UISoundSlider.value = gameData.UISoundVolume;
    }
}
