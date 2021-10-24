using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SkinShop : MonoBehaviour
{
    public UnityEvent BuyEvent;

    [SerializeField] private Button _selectSkin; 
    [SerializeField] private Button _buySkin;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private List<Skin> _skins;
    private GameData _gameData;
    private int _curentSkinIndex;
    private int _skinIndex;

    private void OnEnable()
    {
        _gameData = Save.Instance.GameData;
        BuyEvent?.Invoke();
        for (int i = 0; i < _skins.Count; i++)
        {
            _skins[i].IsCurrent = false;
            if (_gameData.PurchasedSkins.Contains(_skins[i].SkinName))
            {
                _skins[i].Bought = true;
            }

            if (_gameData.SkinName == _skins[i].SkinName)
            {
                _skins[i].IsCurrent = true;
            }

        }
        for (int i = 0; i < _skins.Count; i++)
        {
            if (_skins[i].IsCurrent)
            {
                _curentSkinIndex = i;
                _skins[i].gameObject.SetActive(true);
                _skinIndex = i;
                _buySkin.gameObject.SetActive(false);
                _selectSkin.interactable = false;
                break;
            }
        }
    }

    public void Next()
    {
        _skins[_skinIndex].gameObject.SetActive(false);
        _skinIndex++;
        if (_skinIndex > _skins.Count - 1)
        {
            _skinIndex = 0;
        }

        SkinChange();

    }

    private void SkinChange()
    {
        var skin = _skins[_skinIndex];
        skin.gameObject.SetActive(true);
        if (skin.Bought)
        {
            if (skin.IsCurrent)
            {
                _selectSkin.interactable = false;
            }
            else
            {
                _selectSkin.interactable = true;
            }
            _buySkin.gameObject.SetActive(false);
        }
        else
        {
            _selectSkin.interactable = false;
            _buySkin.gameObject.SetActive(true);
            _priceText.text = skin.Price.ToString();
        }
    }

    public void Previous()
    {
        _skins[_skinIndex].gameObject.SetActive(false);
        _skinIndex--;
        if (_skinIndex < 0)
        {
            _skinIndex = _skins.Count - 1;
        }

        SkinChange();
    }

    public void Buy()
    {
        if(_gameData.Fruits >= _skins[_skinIndex].Price)
        {
            _gameData.Fruits -= _skins[_skinIndex].Price;
            _gameData.PurchasedSkins.Add(_skins[_skinIndex].SkinName);
            _gameData.SkinName = _skins[_skinIndex].SkinName;
            _skins[_curentSkinIndex].IsCurrent = false;
            _curentSkinIndex = _skinIndex;
            _skins[_curentSkinIndex].IsCurrent = true;
            _skins[_curentSkinIndex].Bought = true;
            _buySkin.gameObject.SetActive(false);
            SkinChange();
            BuyEvent?.Invoke();
        }
        else
        {
            Debug.LogError("!!!");
        }
    }

    public void Select()
    {
        _skins[_curentSkinIndex].IsCurrent = false;
        _curentSkinIndex = _skinIndex;
        _gameData.SkinName = _skins[_skinIndex].SkinName;
        _skins[_curentSkinIndex].IsCurrent = true;
        SkinChange();
    }
}
