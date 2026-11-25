using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTexts : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    public GameObject emptyMedal;
    public GameObject goldMedal;
    public GameObject silverMedal;
    public GameObject bronzeMedal;
    private GameManager gameManager;
    private AdsManager adsManager;
    private GameCenterManager gameCenter;
    private const int GoldMedal = 160;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        // Keep in mind this can be null
        gameManager = GameObject.FindGameObjectWithTag(Tags.GAME_MANAGER)?.GetComponent<GameManager>();
        adsManager = GameObject.FindGameObjectWithTag(Tags.ADS_MANAGER)?.GetComponent<AdsManager>();
        gameCenter = GameObject.FindGameObjectWithTag(Tags.GAMECENTER_MANAGER)?.GetComponent<GameCenterManager>();
    }

    void Start()
    {
        DefineScoreText();
        DefineHighScoreText();
        DefineMedal();
        TryAndReportScore();
        TryAndStartAd();
        BlockClimbAchievements();
        CheckForHighScoreAchievement();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void TryAndReportScore()
    {
        // If gamecenter is active report score
        if (gameCenter)
        {
            int highScore = Save.GetHighScore();
            gameCenter.TryToReportScoreToLeaderboards(highScore);
        }
    }

    private void TryAndStartAd()
    {
        // If admanager is active launch the ad
        if (adsManager)
        {
            adsManager.LaunchInterstitialAd();
        }
    }

    private void DefineScoreText()
    {
        scoreText.text = $"Score: {gameManager?.Score ?? 0}";
    }

    private void DefineHighScoreText()
    {
        int highScore = Save.GetHighScore();

        highScoreText.text = $"Highscore: {highScore}";
    }

    private void DefineMedal()
    {
        // get score and calculate medal
        int score = gameManager?.Score ?? 0;

        if (score > GoldMedal)
        {
            goldMedal.SetActive(true);
            gameCenter.ReportAchievement(Achievements.GoldMedal, Achievements.Complete);
        }
        else if (score > 80)
        {
            silverMedal.SetActive(true);
            gameCenter.ReportAchievement(Achievements.SilverMedal, Achievements.Complete);
        }
        else if (score > 40)
        {
            bronzeMedal.SetActive(true);
            gameCenter.ReportAchievement(Achievements.BronzeMedal, Achievements.Complete);
        }
        else
        {
            emptyMedal.SetActive(true);
        }
    }

    private void BlockClimbAchievements()
    {
        // Career block achievements count every block placed, not rows climbed
        float blocksPlaced = Save.GetIntProperty(SaveProperties.BlocksPlaced);

        gameCenter.ReportAchievement(Achievements.ThousandCareerBlocks, blocksPlaced / Achievements.ThousandCareerBlocksCompleted);
        gameCenter.ReportAchievement(Achievements.TenThousandCareerBlocks, blocksPlaced / Achievements.TenThousandCareerBlocksCompleted);
        gameCenter.ReportAchievement(Achievements.HundredThousandCareerBlocks, blocksPlaced / Achievements.HundredThousandCareerBlocksCompleted);
        gameCenter.ReportAchievement(Achievements.MillionCareerBlocks, blocksPlaced / Achievements.MillionCareerBlocksCompleted);
    }

    private void CheckForHighScoreAchievement()
    {
        // get score and calculate medal
        int score = gameManager?.Score ?? 0;

        if (score > Constants.CREATORS_HIGH_SCORE)
        {
            gameCenter.ReportAchievement(Achievements.CreatorsHighScore, Achievements.Complete);
        }
        if (score < Constants.EMBARRASED)
        {
            gameCenter.ReportAchievement(Achievements.EarlyDropBlock, Achievements.Complete);
        }

        int triplePlaces = gameManager?.TriplePlace ?? 0;
        int singlePlaces = gameManager?.SinglePlace ?? 0;

        if (triplePlaces > GoldMedal)
        {
            gameCenter.ReportAchievement(Achievements.TripleStackGold, Achievements.Complete);
        }
        if (singlePlaces > GoldMedal)
        {
            gameCenter.ReportAchievement(Achievements.GoldSingleBlocks, Achievements.Complete);
        }
    }
}
