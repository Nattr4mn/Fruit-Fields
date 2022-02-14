using UnityEngine;

public class AmbientVolume : MonoBehaviour
{
    public static AmbientVolume Instance { get; private set; }

    [SerializeField] private AudioSource _ambientSource;
    [SerializeField] private AudioClip _ambientClip;

    public AudioSource AmbientSource => _ambientSource;
    public AudioClip AmbientClip => _ambientClip;


    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Save object is already exist!");
        }
        else
        {
            Instance = this;
            Instance.PlayMusic(_ambientClip);
            Instance.AmbientSource.volume = Save.Instance.GameData.MusicVolume;
            DontDestroyOnLoad(Instance);
        }

        if(Instance.AmbientSource.clip != _ambientClip)
        {
            Instance.PlayMusic(_ambientClip);
        }
    }

    public void MusicVolumeChange(float value)
    {
        Instance.AmbientSource.volume = value;
        Save.Instance.GameData.MusicVolume = value;
    }

    private void PlayMusic(AudioClip music)
    {
        Instance.AmbientSource.clip = music;
        Instance.AmbientSource.Play();
    }
}
