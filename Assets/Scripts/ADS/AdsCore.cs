using UnityEngine;
using GoogleMobileAds.Api;

public class AdsCore : MonoBehaviour
{
    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
