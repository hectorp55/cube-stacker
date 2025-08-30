using UnityEngine;
using UnityEngine.Rendering;

public class SetAudioSettings : MonoBehaviour
{
    public Volume globalVolume;
    public AudioSource fxSource;
    public AudioSource musicSource;

    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Start()
    {
        DefineMasterVolume();
        DefineSoundFxVolume();
        DefineMusicVolume();
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    void DefineMasterVolume()
    {
        globalVolume.weight = getVolume(Save.GetIntProperty(SaveProperties.MasterVolume));
    }

    void DefineSoundFxVolume()
    {
        fxSource.volume = getVolume(Save.GetIntProperty(SaveProperties.SoundFxVolume));
    }

    void DefineMusicVolume()
    {
        musicSource.volume = getVolume(Save.GetIntProperty(SaveProperties.MusicVolume));
    }

    private float getVolume(int volumeLevel)
    {
        return volumeLevel / 100f;
    }
}
