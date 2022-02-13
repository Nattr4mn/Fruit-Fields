using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        _scoreText.text = _fruitsSpawner.CollectedFruits.ToString() + " / " + _fruitsSpawner.TotalFruits.ToString();
        SaveProgress();
        StartCoroutine(ActivatedStars());
    }

    public void Reward()
    {
        RewardedAds rewardedAds = FindObjectOfType<RewardedAds>();
        rewardedAds.Show();
        rewardedAds.RewardedAd.OnUserEarnedReward += RewardedComplete;
    }

    private void RewardedComplete(object sender, Reward args)
    {
        Save.Instance.GameData.Fruits += _fruitsSpawner.CollectedFruits;
        int collectedFruits = _fruitsSpawner.CollectedFruits * 2;
        _scoreText.text = collectedFruits.ToString() + " / " + _fruitsSpawner.TotalFruits.ToString();
    }

    public int ConvertFruitsToStars()
    {
        int stars = 0;
        int maxStars = _starsObjects.Count;
        if (_fruitsSpawner.TotalStars > 0)
        {
            stars += _fruitsSpawner.CollectedStars;
        }
        stars += Mathf.RoundToInt((maxStars - _fruitsSpawner.TotalStars) * (_fruitsSpawner.CollectedFruits / (float)_fruitsSpawner.TotalFruits));
        return stars;
    }

    private void SaveProgress()
    {
        Save.Instance.GameData.Fruits += _fruitsSpawner.CollectedFruits;
        if (SceneManager.GetActiveScene().buildIndex == Save.Instance.GameData.LastLevel)
            Save.Instance.GameData.LastLevel += 1;
    }

    private IEnumerator ActivatedStars()
    {
        int stars = ConvertFruitsToStars();
        int starsCount = 0;
        while(starsCount != stars)
        {
            _starsObjects[starsCount].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            starsCount++;
        }
    }
}
