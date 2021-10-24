using UnityEngine;
using UnityEngine.UI;

public class Buff : MonoBehaviour
{
    public string BuffName => _buffName;
    public int Price => _price;

    [SerializeField] private string _buffName;
    [SerializeField] private int _price;
}
