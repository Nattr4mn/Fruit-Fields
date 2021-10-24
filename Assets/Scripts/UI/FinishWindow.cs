using System.Collections;
using TMPro;
using UnityEngine;

public class FinishWindow : MonoBehaviour
{
    [SerializeField] private AudioSource _effectsSource;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private GameObject _firstStar;
    [SerializeField] private GameObject _secondStar;
    [SerializeField] private GameObject _thirdStar;
    [SerializeField] private FruitsSpawner _fruitsSpawner;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void Finish()
    {
        _effectsSource.PlayOneShot(_winSound);
        _scoreText.text = _fruitsSpawner.CollectedFruits.ToString() + " / " + _fruitsSpawner.TotalFruit.ToString();
        Save.Instance.GameData.Fruits += _fruitsSpawner.CollectedFruits;
        StartCoroutine(ActivatedStars());
    }

    private IEnumerator ActivatedStars()
    {
        if (_fruitsSpawner.CollectedFruits >= _fruitsSpawner.TotalFruit * 0.4f)
        {
            _firstStar.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }

        if (_fruitsSpawner.CollectedFruits >= _fruitsSpawner.TotalFruit * 0.7f)
        {
            _secondStar.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }

        if (_fruitsSpawner.CollectedFruits >= _fruitsSpawner.TotalFruit * 0.9f)
        {
            _thirdStar.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }

        yield return null;
    }
}
