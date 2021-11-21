using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class Save : MonoBehaviour
{
    public static Save Instance { get; private set; }
    public UnityEvent LoadComplete;

    public GameData GameData;

    [SerializeField] private string _saveFileName = "GameData";

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Save object is already exist!");
        }
        else
        {
            Instance = this;
            Instance.LoadData();
            DontDestroyOnLoad(this);
        }
    }

    private void LoadData()
    {
        var path = LoadPath();
        if(File.Exists(path))
        {
            Instance.GameData = JsonUtility.FromJson<GameData>(File.ReadAllText(path));
            Instance.LoadComplete.Invoke();
        }
    }

    private void SaveData()
    {
        var path = LoadPath();
        File.WriteAllText(path, JsonUtility.ToJson(Instance.GameData));
    }

    private string LoadPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Path.Combine(Application.persistentDataPath, _saveFileName + ".json");
#else
        return Path.Combine(Application.dataPath, _saveFileName + ".json");
#endif
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        SaveData();
    }
#else
    private void OnApplicationQuit()
    {
        SaveData();
    }
#endif
}
