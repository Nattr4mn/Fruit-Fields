using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishWindow : MonoBehaviour
{
    [SerializeField] private AudioSource _effectsSource;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private List<GameObject> _starsObjects;
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
        var procent = 0.3f;

        foreach(var star in _starsObjects)
        {
            if(_fruitsSpawner.CollectedFruits >= _fruitsSpawner.TotalFruit * procent)
            {
                star.SetActive(true);
                yield return new WaitForSeconds(0.3f);
                procent += 0.3f;
            }
        }
    }
}
