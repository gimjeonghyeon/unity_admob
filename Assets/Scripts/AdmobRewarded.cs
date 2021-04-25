using System;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdmobRewarded : MonoBehaviour
{    
    private readonly string unitID = "ca-app-pub-3940256099942544/5224354917";
    private readonly string testUnitID = "ca-app-pub-3940256099942544/5224354917";

    private RewardedAd rewardedAd;

    private void Start()
    {
        InitAd();
    }

    private void InitAd()
    {
        string id = Debug.isDebugBuild ? testUnitID : unitID;
        
        rewardedAd = new RewardedAd(id);
        
        var request = new AdRequest.Builder().Build();
        
        rewardedAd.LoadAd(request);
        
        // 광고 로드 완료
        rewardedAd.OnAdLoaded += (sender, args) => Debug.Log("OnAdLoaded");
        // 광고 로드 실패
        rewardedAd.OnAdFailedToLoad += (sender, args) => Debug.Log("OnAdFailedToLoad");
        // 광고 표시가 실행될 때
        rewardedAd.OnAdOpening += (sender, args) => Debug.Log("OnAdOpening");
        // Called when an ad request failed to show.
        rewardedAd.OnAdFailedToShow += (sender, args) => Debug.Log("OnAdFailedToShow");
        // Called when the user should be rewarded for interacting with the ad.
        rewardedAd.OnUserEarnedReward += (sender, args) => Debug.Log("OnUserEarnedReward");
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += (sender, args) => Debug.Log("OnAdClosed");
    }

    public void OnClickRewardedAd()
    {
        StartCoroutine("ShowAd");
    }

    private IEnumerator ShowAd()
    {
        yield return new WaitUntil(() => rewardedAd.IsLoaded());
        rewardedAd.Show();
    }
}
