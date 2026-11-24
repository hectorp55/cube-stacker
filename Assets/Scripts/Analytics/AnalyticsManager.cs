using System;
using Firebase;
using Firebase.Analytics;
using UnityEngine;

public class AnalyticsManager : Singleton
{
    private const string ROUND_PLAYED_EVENT = "round_played";
    private const string AD_SHOWN_EVENT = "ad_shown";
    private const string TRIPLE_PLACES_PARAMETER = "triple_places";
    private const string SINGLE_PLACES_PARAMETER = "single_places";

    // Events are skipped until Firebase has finished starting up
    private static bool isReady = false;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        if (IsDuplicate) return;

        DontDestroyOnLoad(gameObject);
        InitializeFirebase();
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    // Call this when a round ends
    public static void RecordRoundPlayed(int score, int triplePlaces, int singlePlaces)
    {
        if (!isReady) return;

        FirebaseAnalytics.LogEvent(
            ROUND_PLAYED_EVENT,
            new Parameter(FirebaseAnalytics.ParameterScore, score),
            new Parameter(TRIPLE_PLACES_PARAMETER, triplePlaces),
            new Parameter(SINGLE_PLACES_PARAMETER, singlePlaces));
    }

    // Call this when an ad appears on screen
    public static void RecordAdShown()
    {
        if (!isReady) return;

        FirebaseAnalytics.LogEvent(AD_SHOWN_EVENT);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    // Users, sessions and engagement time are tracked automatically once this is done
    private async void InitializeFirebase()
    {
        try
        {
            DependencyStatus status = await FirebaseApp.CheckAndFixDependenciesAsync();

            if (status != DependencyStatus.Available)
            {
                Debug.LogError($"Firebase could not start: {status}");
                return;
            }

            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            isReady = true;
            Debug.Log("Firebase Analytics ready");
        }
        catch (Exception e)
        {
            // Analytics should never get in the way of the game
            Debug.LogException(e);
        }
    }
}
