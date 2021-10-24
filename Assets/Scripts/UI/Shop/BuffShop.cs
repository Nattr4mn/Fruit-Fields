using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class BuffShop : MonoBehaviour
{
    public UnityEvent BuyEvent;

    [SerializeField] public Button _healBuyingButton;
    [SerializeField] public Buff _healBuff;
    [SerializeField] public TextMeshProUGUI _healPriceText;

    [SerializeField] public Button _doubleSpeedBuyingButton;
    [SerializeField] public Buff _doubleSpeedBuff;
    [SerializeField] public TextMeshProUGUI _doubleSpeedPriceText;

    [SerializeField] public Button _immortalityBuyingButton;
    [SerializeField] public Buff _immortalityBuff;
    [SerializeField] public TextMeshProUGUI _immortalityPriceText;

    private GameData _gameData;

    private void Start()
    {
        _gameData = Save.Instance.GameData;
        _healPriceText.text = _healBuff.Price.ToString();
        _doubleSpeedPriceText.text = _doubleSpeedBuff.Price.ToString();
        _immortalityPriceText.text = _immortalityBuff.Price.ToString();
    }

    public void BuyHeal()
    {
        Buy(_healBuff.Price, ref _gameData.Heal);
    }

    public void BuyDoubleSpeed()
    {
        Buy(_doubleSpeedBuff.Price, ref _gameData.DoubleSpeed);
    }

    public void BuyImmortality()
    {
        Buy(_immortalityBuff.Price, ref _gameData.Immortality);
    }

    private void Buy(int price, ref int buffQuantitr)
    {
        if (price <= _gameData.Fruits)
        {
            buffQuantitr++;
            _gameData.Fruits -= price;
        }
        BuyEvent?.Invoke();
    }

}
