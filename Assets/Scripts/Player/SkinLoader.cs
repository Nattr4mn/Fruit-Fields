using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    public GameObject CurrentSkin => _currentSkin;

    [SerializeField] private List<Character> _skinList;
    private GameObject _currentSkin;

    public void LoadSkin()
    {
        var currentSkin = Save.Instance.GameData.SkinName;

        foreach(var skin in _skinList)
        {
            if(skin.CharacterName == currentSkin)
            {
                skin.gameObject.SetActive(true);
                _currentSkin = skin.gameObject;
            }
            else
            {
                skin.gameObject.SetActive(false);
            }
        }
    }
}
