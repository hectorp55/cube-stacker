using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Apple.GameKit;
using Apple.GameKit.Leaderboards;
using UnityEngine.UI;
using System.Linq;

public class GameCenterManager : Singleton
{
    public GameObject GameCenterButton;
    private string Signature;
    private string TeamPlayerID;
    private string Salt;
    private string PublicKeyUrl;
    private string Timestamp;

    // ===========================================================
    // Mono Methods
    // ===========================================================
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Login();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    // Call this when a player needs to report their score to the leaderboard
    public async void TryToReportScoreToLeaderboards(long score)
    {
        var context = 0;

        // Get all active leaderboards
        var allLeaderboards = await GKLeaderboard.LoadLeaderboards();

        // Report current score to all active leaderboards
        List<Task> reportTasks = new List<Task>();
        foreach (var leaderboard in allLeaderboards)
        {
            reportTasks.Add(leaderboard.SubmitScore(score, context, GKLocalPlayer.Local));
        }
        await Task.WhenAll(reportTasks);
    }

    // Call this when a player completes an achievement
    public async void ReportAchievement(string achievementId)
    {
        var progressPercentage = 100;
        var showCompletionBanner = true;

        var achievements = await GKAchievement.LoadAchievements();

        var achievement = achievements.FirstOrDefault(a => a.Identifier == achievementId);
        // If null, initialize it
        achievement ??= GKAchievement.Init(achievementId);

        // If not already completed, update it
        if (!achievement.IsCompleted)
        {
            achievement.PercentComplete = progressPercentage;
            achievement.ShowCompletionBanner = showCompletionBanner;

            await GKAchievement.Report(achievement);
        }
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private async void Login()
    {
        GKLocalPlayer.AuthenticateUpdate += AuthenticateSuccess;

        if (!GKLocalPlayer.Local.IsAuthenticated)
        {
            // Perform the authentication.
            var player = await GKLocalPlayer.Authenticate();
            Debug.Log($"GameKit Authentication: player {player}");
        }
        else
        {
            Debug.Log("AppleGameCenter player already logged in.");
        }
    }

    private async void ReplaceProfileIcon()
    {
        var player = GKLocalPlayer.Local;
        var photo = await player.LoadPhoto(GKPlayer.PhotoSize.Small);

        if (photo)
        {
            // Define the rectangle for the sprite (using the whole texture in this example)
            Rect spriteRect = new Rect(0, 0, photo.width, photo.height);

            // Define the pivot point (center of the sprite)
            Vector2 pivot = new Vector2(0.5f, 0.5f); // Center pivot

            // Pixels per unit (controls the sprite's size in world units)
            float pixelsPerUnit = 100f;

            // Create the Sprite
            Sprite newSprite = Sprite.Create(photo, spriteRect, pivot, pixelsPerUnit);

            GameCenterButton.GetComponent<Image>().sprite = newSprite;
            GameCenterButton.SetActive(true);
        }
    }

    private void AuthenticateSuccess(GKLocalPlayer localPlayer)
    {
        Debug.Log("Profile Icon Updated");
        ReplaceProfileIcon();
    }
}
