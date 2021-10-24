using TMPro;
using UnityEngine;

public class FruitsQuantity : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fruitsNumbers;

    public void UpdateNumber()
    {
        _fruitsNumbers.text = Save.Instance.GameData.Fruits.ToString();
    }
}
