using UnityEngine;

[CreateAssetMenu(menuName = "Create skin")]
public class Skin : ScriptableObject
{
    public string SkinName => _skinName;
    public int Price => _price;
    public Sprite PreviewSprite => _previewSprite;
    public GameObject SkinObject => _skinObject;

    [SerializeField] private string _skinName;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _previewSprite;
    [SerializeField] private GameObject _skinObject;
}
