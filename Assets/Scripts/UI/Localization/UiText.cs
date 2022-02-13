using UnityEngine;
using TMPro;

public class UiText : MonoBehaviour
{
    [SerializeField] private string _textKey;
    [SerializeField] private TextMeshProUGUI _textMP;

    private void Start()
    {
        _textMP.text = Localization.Instance.UiLocalization[_textKey];
    }
}
