using UnityEngine;

public class SoundEffects : Singleton
{
    public AudioClip placingSoundEffect;
    public AudioSource audioSource;

    private float minPitch = 0.9f;
    private float maxPitch = 1.1f;

    // ===========================================================
    // Public Methods
    // ===========================================================

    // Call this method to play the placing sound effect
    public void PlayPlaceSound()
    {
        playSound(placingSoundEffect);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void playSound(AudioClip soundEffect)
    {
        if (soundEffect != null)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.PlayOneShot(soundEffect);
        }
        else
        {
            Debug.LogWarning("SoundEffect not assigned!");
        }
    }
}
