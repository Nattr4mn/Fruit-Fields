using GoogleMobileAds.Api;
using UnityEngine;

public class RewardedAds : MonoBehaviour
{
    private RewardedAd _rewardedAd;
    //private const string adUnitId = "ca-app-pub-3940256099942544/5224354917"; //test key
    private const string adUnitId = "ca-app-pub-6267425863853814/1028003458";

    public RewardedAd RewardedAd => _rewardedAd;

    private void OnEnable()
    {
        _rewardedAd = new RewardedAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        _rewardedAd.LoadAd(request);
    }

    public void Show()
    {
        if (_rewardedAd.IsLoaded())
        {
            _rewardedAd.Show();
        }
    }
}
