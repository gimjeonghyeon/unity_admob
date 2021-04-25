using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.UI;

public class AdmobBanner : MonoBehaviour
{
    private readonly string unitID = "ca-app-pub-3940256099942544/6300978111";
    private readonly string testUnitID = "ca-app-pub-3940256099942544/6300978111";

    private readonly string testDeviceID = "50888EAC7F807CCC"; // galaxy s10 device id

    private BannerView banner;

    public AdPosition position;
    public Text buttonText;
    
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

    public void ToggleAd(Toggle toggle)
    {
        if (toggle.isOn)
        {
            banner.Show();
            buttonText.text = "Hide Banner Ad";
            Debug.Log("Show");
            
        }
        else
        {
            banner.Hide();
            buttonText.text = "Show Banner Ad";
            Debug.Log("Hide");

        }
    }

    public void DestroyAd()
    {
        banner.Destroy();
    }
}
