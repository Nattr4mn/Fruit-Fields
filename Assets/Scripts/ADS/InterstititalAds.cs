using UnityEngine;
using GoogleMobileAds.Api;

public class InterstititalAds : MonoBehaviour
{
    private InterstitialAd _interstitital;
    private const string adUnitId = "ca-app-pub-3940256099942544/1033173712";

    private void OnEnable()
    {
        _interstitital = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        _interstitital.LoadAd(request);
    }

    public void Show()
    {
        if(_interstitital.IsLoaded())
        {
           _interstitital.Show();     
        }
    }
}
