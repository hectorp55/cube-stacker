using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LogoAnimation : MonoBehaviour
{
    public Image logoImage;
    public TextMeshProUGUI logoText;
    private float fadeInDuration = 1.5f;
    private float fadeOutDuration = 0.3f;
    private float maxScale = 1.1f; // Final scale after both fade in/out
    private float fadeOutEndAlpha = 0f;

    private Vector3 originalScale;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        originalScale = transform.localScale;

        // Start the effect
        StartCoroutine(GrowFadeInOut());
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void NavigateToGame()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private IEnumerator GrowFadeInOut()
    {
        float timer = 0f;

        // Fade in while scaling
        while (timer < fadeInDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeInDuration);

            // Scale linearly from original to maxScale
            transform.localScale = originalScale * Mathf.Lerp(1f, maxScale, t);

            // Fade in
            // SetAlpha(t);

            yield return null;
        }

        // Fade out while continuing scale up
        timer = 0f;
        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / fadeOutDuration);

            // Keep scale capped at maxScale
            transform.localScale = originalScale * Mathf.Lerp(1f, maxScale, 1f);

            // Fade alpha from 1 to fadeOutEndAlpha
            SetAlpha(Mathf.Lerp(1f, fadeOutEndAlpha, t));

            yield return null;
        }

        // Navigate to main game
        NavigateToGame();
    }
    
    private void SetAlpha(float alpha)
    {
        if (logoImage != null)
        {
            Color c = logoImage.color;
            c.a = alpha;
            logoImage.color = c;
        }

        if (logoText != null)
        {
            Color c = logoText.color;
            c.a = alpha;
            logoText.color = c;
        }
    }
}
