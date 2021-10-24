using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public string SkinName => _skinName;
    public int Price => _price;

    public bool Bought;
    public bool IsCurrent;

    [SerializeField] private string _skinName;
    [SerializeField] private int _price;
}
