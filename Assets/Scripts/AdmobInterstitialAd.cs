using System;
using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdmobInterstitialAd : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-3940256099942544/1033173712";
    private readonly string testUnitID = "ca-app-pub-3940256099942544/1033173712";

    private readonly string testDeviceID = ""; // 테스트 기기를 추가할 경우 사용

    private InterstitialAd interstitialAd;

    private void Start()
    {
        InitAd();
        Invoke("Show", 10f);
    }

    private void InitAd()
    {
        string id = Debug.isDebugBuild ? testDeviceID : unitID;
        
        interstitialAd = new InterstitialAd(id);

        var request = new AdRequest.Builder().Build();
        
        interstitialAd.LoadAd(request);
        interstitialAd.OnAdLoaded += (sender, args) => Debug.Log("광고가 로드됨");
        interstitialAd.OnAdClosed += (sender, args) => Debug.Log("광고가 닫힘");
    }

    public void Show()
    {
        StartCoroutine("ShowInterstitialAd");
    }

    private IEnumerator ShowInterstitialAd()
    {
        while (!interstitialAd.IsLoaded())
        {
            yield return null;
        }
        
        interstitialAd.Show();
    }
}
