using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public float SoundEffectVolume = 1f;
    public float MusicVolume = 1f;
    public string Language = "russian";
    public string SkinName = "PinkMan";
    public int Fruits = 10000;
    public int Heal = 0;
    public int DoubleSpeed = 0;
    public int Immortality = 0;
    public int LastLevel = 1;
    public Dictionary<string, int> BuffList = new Dictionary<string, int>();
    public List<string> PurchasedSkins = new List<string>() { "PinkMan" };
}
