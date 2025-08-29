using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Apple.GameKit;
using UnityEngine.UI;
using System.Linq;

public class GameCenterManager : MonoBehaviour
{
    public GameObject GameCenterProfileIcon;
    public Image profilePhotoImage;

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
        // Login();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    // Call this when a player needs to report their score to the leaderboard
    public async void TryToReportScoreToLeaderboard(long score, string leaderboardId)
    {
        var context = 0;

        // Filter leadboards by params string[] identifiers
        // var leaderboards = await GKLeaderboard.LoadLeaderboards(leaderboardId);
        // var leaderboard = leaderboards.FirstOrDefault();

        // // Submit
        // await leaderboard.SubmitScore(score, context, GKLocalPlayer.Local);
    }

    // Call this when a player completes an achievement
    public async void ReportAchievement(string achievementId)
    {
        var progressPercentage = 100;
        var showCompletionBanner = true;

        var achievements = await GKAchievement.LoadAchievements();

        // Only completed achievements are returned.
        var achievement = achievements.FirstOrDefault(a => a.Identifier == achievementId);

        // If null, initialize it
        achievement ??= GKAchievement.Init(achievementId);

        if(!achievement.IsCompleted) {
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
        if (!GKLocalPlayer.Local.IsAuthenticated)
        {
            // Perform the authentication.
            var player = await GKLocalPlayer.Authenticate();
            Debug.Log($"GameKit Authentication: player {player}");

            // Grab the display name.
            var localPlayer = GKLocalPlayer.Local;
            Debug.Log($"Local Player: {localPlayer.DisplayName}");

            // Fetch the items.
            var fetchItemsResponse = await GKLocalPlayer.Local.FetchItems();

            Signature = Convert.ToBase64String(fetchItemsResponse.GetSignature());
            TeamPlayerID = localPlayer.TeamPlayerId;
            Debug.Log($"Team Player ID: {TeamPlayerID}");
            Salt = Convert.ToBase64String(fetchItemsResponse.GetSalt());
            PublicKeyUrl = fetchItemsResponse.PublicKeyUrl;
            Timestamp = fetchItemsResponse.Timestamp.ToString();

            // TODO: load player photo
            // var profilePhoto = await player.LoadPhoto(GKPlayer.PhotoSize(100));
            // if (profilePhoto)
            // {
            //     profilePhotoImage.Image = profilePhoto;
            // }
        }
        else
        {
            Debug.Log("AppleGameCenter player already logged in.");
        }
    }
}
