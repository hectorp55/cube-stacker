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
        DefineMasterVolume(Save.GetIntProperty(SaveProperties.MasterVolume));
        DefineSoundFxVolume(Save.GetIntProperty(SaveProperties.SoundFxVolume));
        DefineMusicVolume(Save.GetIntProperty(SaveProperties.MusicVolume));
    }

    // ===========================================================
    // Public Methods
    // ===========================================================   

    public void DefineMasterVolume(int value)
    {
        globalVolume.weight = getVolume(value);
    }

    public void DefineSoundFxVolume(int value)
    {
        fxSource.volume = getVolume(value);
    }

    public void DefineMusicVolume(int value)
    {
        musicSource.volume = getVolume(value);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================   

    private float getVolume(int volumeLevel)
    {
        return volumeLevel / 100f;
    } 
}
