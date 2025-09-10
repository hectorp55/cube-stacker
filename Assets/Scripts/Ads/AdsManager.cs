using Unity.Services.LevelPlay;
using UnityEngine;

public class AdsManager : Singleton
{
    public GameObject uiElement;

    private const string IOS_APP_ID = "2371a163d";
    private const string GAMEOVER_AD_ID = "d7zkx631ve8ukqiv";
    private LevelPlayInterstitialAd interstitialAd;
    private int roundsSinceLastAd = 0;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        IronSource.Agent.setMetaData("is_test_suite", "enable"); 
        LevelPlay.OnInitSuccess += SdkInitializationCompletedEvent;
        LevelPlay.OnInitFailed += SdkInitializationFailedEvent;

        // SDK init
        LevelPlay.Init(IOS_APP_ID);
    }

    public void LaunchInterstitialAd()
    {
        if (roundsSinceLastAd >= 3)
        {
            LoadInterstitialAd();
        }
        else
        {
            roundsSinceLastAd += 1;
        }
    }

    public void LaunchTestSuite()
    {
        IronSource.Agent.launchTestSuite();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void EnableAds()
    {
        // TODO: block the ad setup if they paid the no ads cost
        CreateInterstitialAd();
    }

    private void CreateInterstitialAd() {
	      //Create InterstitialAd instance
        interstitialAd= new LevelPlayInterstitialAd(GAMEOVER_AD_ID);

        //Subscribe InterstitialAd events
        interstitialAd.OnAdLoaded += InterstitialOnAdLoadedEvent;
        interstitialAd.OnAdLoadFailed += InterstitialOnAdLoadFailedEvent;
        interstitialAd.OnAdDisplayed += InterstitialOnAdDisplayedEvent;
        interstitialAd.OnAdDisplayFailed += InterstitialOnAdDisplayFailedEvent;
        interstitialAd.OnAdClicked += InterstitialOnAdClickedEvent;
        interstitialAd.OnAdClosed += InterstitialOnAdClosedEvent;
        interstitialAd.OnAdInfoChanged += InterstitialOnAdInfoChangedEvent;
    }
    private void LoadInterstitialAd() {
        //Load or reload InterstitialAd 	
        interstitialAd.LoadAd();
    }
    private void ShowInterstitialAd() {
        //Show InterstitialAd, check if the ad is ready before showing
        if (interstitialAd.IsAdReady())
        {
            interstitialAd.ShowAd();
            roundsSinceLastAd = 0;
        }
    }

    // ===========================================================
    // Event Handlers
    // ===========================================================

    void SdkInitializationCompletedEvent(LevelPlayConfiguration config)
    {
        Debug.Log($"[LevelPlaySample] Received SdkInitializationCompletedEvent with Config: {config}");
        EnableAds();
        // uiElement.SetActive(true);
    }

    void SdkInitializationFailedEvent(LevelPlayInitError error)
    {
        Debug.Log($"[LevelPlaySample] Received SdkInitializationFailedEvent with Error: {error}");
    }

    void InterstitialOnAdLoadedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdLoadedEvent With AdInfo: {adInfo}");
        ShowInterstitialAd();
    }

    void InterstitialOnAdLoadFailedEvent(LevelPlayAdError error)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdLoadFailedEvent With Error: {error}");
    }

    void InterstitialOnAdDisplayedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdDisplayedEvent With AdInfo: {adInfo}");
    }
    void InterstitialOnAdDisplayFailedEvent(LevelPlayAdDisplayInfoError infoError)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdDisplayFailedEvent With InfoError: {infoError}");
    }
    void InterstitialOnAdClickedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdClickedEvent With AdInfo: {adInfo}");
    }

    void InterstitialOnAdClosedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdClosedEvent With AdInfo: {adInfo}");
    }

    void InterstitialOnAdInfoChangedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdInfoChangedEvent With AdInfo: {adInfo}");
    }
}
