using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    [SerializeField] private List<Skin> _skinList;
    private Skin _currentSkin;

    public Skin CurrentSkin => _currentSkin;

    public void LoadSkin()
    {
        var currentSkin = Save.Instance.GameData.SkinName;

        foreach(var skin in _skinList)
        {
            if(skin.SkinName == currentSkin)
            {
                _currentSkin = skin;
                break;
            }
        }
    }
}
