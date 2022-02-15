using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public float SoundEffectVolume = 0.5f;
    public float UISoundVolume = 0.5f;
    public float MusicVolume = 0.5f;
    public string Language = "russian";
    public string SkinName = "PinkMan";
    public int Fruits = 0;
    public int Heal = 0;
    public int DoubleSpeed = 0;
    public int Immortality = 0;
    public int LastLevel = 1;
    public Dictionary<string, int> BuffList = new Dictionary<string, int>();
    public List<string> PurchasedSkins = new List<string>() { "PinkMan" };
}
