using UnityEngine;
using UnityEngine.Audio;

public class SetAudioSettings : MonoBehaviour
{
    public AudioMixer mixer;

    private const string Main = "MainVolume";
    private const string Fx = "FxVolume";
    private const string Music = "MusicVolume";

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
        SetVolume(Main, getVolume(value));
    }

    public void DefineSoundFxVolume(int value)
    {
        SetVolume(Fx, getVolume(value));
    }

    public void DefineMusicVolume(int value)
    {
        SetVolume(Music, getVolume(value));
    }

    public void SetVolume(string mixerProp, float value)
    {
        // value expected in decibels
        mixer.SetFloat(mixerProp, value);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================   

    private float getVolume(int volumeLevel)
    {
        float sliderValue = volumeLevel / 100f;
        return Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20f;
    } 
}
