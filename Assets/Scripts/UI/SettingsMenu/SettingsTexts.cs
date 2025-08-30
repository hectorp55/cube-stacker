using UnityEngine;
using UnityEngine.UI;

public class SettingsTexts : MonoBehaviour
{
    public Slider maxVolumeSlider;
    public Slider soundFxSlider;
    public Slider musicVolumeSlider;

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
        maxVolumeSlider.value = Save.GetIntProperty(SaveProperties.MasterVolume);
    }

    void DefineSoundFxVolume()
    {
        soundFxSlider.value = Save.GetIntProperty(SaveProperties.SoundFxVolume);
    }
    
    void DefineMusicVolume()
    {
        musicVolumeSlider.value = Save.GetIntProperty(SaveProperties.MusicVolume);
    }
}
