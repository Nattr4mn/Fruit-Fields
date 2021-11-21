using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SkinShop : MonoBehaviour
{
    public UnityEvent BuyEvent;

    [SerializeField] private Button _selectButton;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Image _skinPreview;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private List<Skin> _skins;
    private GameData _gameData;
    private int _skinIndex;

    private void OnEnable()
    {
        _gameData = Save.Instance.GameData;
        BuyEvent?.Invoke();

        for (int i = 0; i < _skins.Count; i++)
        {
            if (_gameData.SkinName.Contains(_skins[i].SkinName))
            {
                _skinIndex = i;
                _selectButton.interactable = false;
                _buyButton.gameObject.SetActive(false);
                _skinPreview.sprite = _skins[i].PreviewSprite;
                break;
            }
        }
    }

    public void Next()
    {
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
        _skinPreview.sprite = skin.PreviewSprite;
        if(_gameData.PurchasedSkins.Contains(skin.SkinName))
        {
            if (_gameData.SkinName.Contains(skin.SkinName))
            {
                _selectButton.interactable = false;
            }
            else
            {
                _selectButton.interactable = true;
            }
            _buyButton.gameObject.SetActive(false);
        }
        else
        {
            _selectButton.interactable = false;
            _buyButton.gameObject.SetActive(true);
            _priceText.text = skin.Price.ToString();
        }
    }

    public void Previous()
    {
        _skinIndex--;
        if (_skinIndex < 0)
        {
            _skinIndex = _skins.Count - 1;
        }

        SkinChange();
    }

    public void Buy()
    {
        if (_gameData.Fruits >= _skins[_skinIndex].Price)
        {
            _gameData.Fruits -= _skins[_skinIndex].Price;
            _gameData.PurchasedSkins.Add(_skins[_skinIndex].SkinName);
            _gameData.SkinName = _skins[_skinIndex].SkinName;
            _buyButton.gameObject.SetActive(false);
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
        _gameData.SkinName = _skins[_skinIndex].SkinName;
        SkinChange();
    }
}
