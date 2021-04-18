using GoogleMobileAds.Api;
using UnityEngine;

public class AdmobBanner : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-3940256099942544/6300978111";
    private readonly string testUnitID = "ca-app-pub-3940256099942544/6300978111";

    private readonly string testDeviceID = "50888EAC7F807CCC"; // galaxy s10 device id

    private BannerView banner;

    public AdPosition position;

    private void Start()
    {
        InitAd();
    }
    
    private void InitAd()
    {
        string id = Debug.isDebugBuild ? testUnitID : unitID;

        banner = new BannerView(id, AdSize.SmartBanner, position);

        var request = new AdRequest.Builder().AddTestDevice(testDeviceID).Build();

        banner.LoadAd(request);
    }

    public void ToggleAd(bool active)
    {
        if (active)
        {
            banner.Show();
        }
        else
        {
            banner.Hide();
        }
    }

    public void DestroyAd()
    {
        banner.Destroy();
    }
}
