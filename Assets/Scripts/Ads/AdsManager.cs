using Unity.Services.LevelPlay;
using UnityEngine;

public class AdsManager : Singleton
{
    public GameObject uiElement;

    private const string IOS_APP_ID = "2371a163d";
    private const string GAMEOVER_AD_ID = "d7zkx631ve8ukqiv";
    // Show an ad on every Nth game over
    private const int ROUNDS_PER_AD = 4;
    // Seconds to wait before trying to load again after a failure
    private const float RELOAD_DELAY = 30f;
    private LevelPlayInterstitialAd interstitialAd;
    private int roundsSinceLastAd = 0;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        if (IsDuplicate) return;

        DontDestroyOnLoad(gameObject);

        LevelPlay.SetMetaData("is_test_suite", "enable"); 
        LevelPlay.OnInitSuccess += SdkInitializationCompletedEvent;
        LevelPlay.OnInitFailed += SdkInitializationFailedEvent;

        // SDK init
        LevelPlay.Init(IOS_APP_ID);
    }

    void OnDestroy()
    {
        if (IsDuplicate) return;

        LevelPlay.OnInitSuccess -= SdkInitializationCompletedEvent;
        LevelPlay.OnInitFailed -= SdkInitializationFailedEvent;
        interstitialAd?.DestroyAd();
    }

    // Called on every game over. Shows the preloaded ad once enough rounds have passed.
    public void LaunchInterstitialAd()
    {
        roundsSinceLastAd += 1;

        if (roundsSinceLastAd >= ROUNDS_PER_AD)
        {
            // If the ad isn't ready yet, the counter stays put and we try again next game over
            ShowInterstitialAd();
        }
    }

    public void LaunchTestSuite()
    {
        LevelPlay.LaunchTestSuite();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void EnableAds()
    {
        // TODO: block the ad setup if they paid the no ads cost
        CreateInterstitialAd();
        // Preload so the ad is ready the moment it's needed
        LoadInterstitialAd();
    }

    private void CreateInterstitialAd() {
        //Create InterstitialAd instance
        interstitialAd = new LevelPlayInterstitialAd(GAMEOVER_AD_ID);

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
        interstitialAd?.LoadAd();
    }

    private void ShowInterstitialAd() {
        //Show InterstitialAd, check if the ad is ready before showing
        if (interstitialAd != null && interstitialAd.IsAdReady())
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
    }

    void InterstitialOnAdLoadFailedEvent(LevelPlayAdError error)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdLoadFailedEvent With Error: {error}");
        Invoke(nameof(LoadInterstitialAd), RELOAD_DELAY);
    }

    void InterstitialOnAdDisplayedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdDisplayedEvent With AdInfo: {adInfo}");
        AnalyticsManager.RecordAdShown();
    }
    void InterstitialOnAdDisplayFailedEvent(LevelPlayAdInfo adInfo, LevelPlayAdError error)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdDisplayFailedEvent With AdInfo: {adInfo} and Error: {error}");
        // This ad can't be shown, so fetch a fresh one
        LoadInterstitialAd();
    }
    void InterstitialOnAdClickedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdClickedEvent With AdInfo: {adInfo}");
    }

    void InterstitialOnAdClosedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdClosedEvent With AdInfo: {adInfo}");
        // Preload the next ad
        LoadInterstitialAd();
    }

    void InterstitialOnAdInfoChangedEvent(LevelPlayAdInfo adInfo)
    {
        Debug.Log($"[LevelPlaySample] Received InterstitialOnAdInfoChangedEvent With AdInfo: {adInfo}");
    }
}
