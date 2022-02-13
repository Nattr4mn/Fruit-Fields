using UnityEngine;
using TMPro;

public class Version : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _version;

    private void Start()
    {
        _version.text = "v " + Application.version;
    }
}
