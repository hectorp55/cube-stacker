using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsActions : MonoBehaviour
{
    private SetAudioSettings audioSettings;


    // ===========================================================
    // Mono Methods
    // ===========================================================

    void Awake()
    {
        GameObject musicBox = GameObject.FindGameObjectWithTag(Tags.MUSIC_BOX);
        if (musicBox)
        {
            audioSettings = musicBox.GetComponent<SetAudioSettings>();
        }
    }

    // ===========================================================
    // Public Methods
    // ===========================================================

    public void NavigateBack()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }

    public void OnMasterVolumeSliderValueChanged(float value)
    {
        int convertedValue = (int)value;
        Save.SaveIntProperty(SaveProperties.MasterVolume, convertedValue);
        TrySetPropertyForMusicBox(SaveProperties.MasterVolume, convertedValue);
    }

    public void OnFxVolumeSliderValueChanged(float value)
    {
        int convertedValue = (int)value;
        Save.SaveIntProperty(SaveProperties.SoundFxVolume, convertedValue);
        TrySetPropertyForMusicBox(SaveProperties.SoundFxVolume, convertedValue);
    }

    public void OnMusicVolumeSliderValueChanged(float value)
    {
        int convertedValue = (int)value;
        Save.SaveIntProperty(SaveProperties.MusicVolume, convertedValue);
        TrySetPropertyForMusicBox(SaveProperties.MusicVolume, convertedValue);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================

    private void TrySetPropertyForMusicBox(string property, int value)
    {
        if (audioSettings)
        {
            if (property == SaveProperties.MasterVolume) {
                audioSettings.DefineMasterVolume(value);
            } else if (property == SaveProperties.SoundFxVolume)
            {
                audioSettings.DefineSoundFxVolume(value);
            } else if (property == SaveProperties.MusicVolume)
            {
                audioSettings.DefineMusicVolume(value);
            }
        }
    }
}
