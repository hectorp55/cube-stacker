using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInObject : MonoBehaviour
{
    public float fadeDuration = 0.1f; // How long the fade takes
    private Image uiImage;


    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        uiImage = GetComponent<Image>();
    }

    void Start()
    {
        // Start fully transparent
        Color c = uiImage.color;
        c.a = 0f;
        uiImage.color = c;

        // Begin fade in
        StartCoroutine(FadeIn());
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color c = uiImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsed / fadeDuration);
            uiImage.color = c;
            yield return null;
        }
    }
}
