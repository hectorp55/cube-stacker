using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsActions : MonoBehaviour
{
    // ===========================================================
    // Public Methods
    // ===========================================================

    public void NavigateBack()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }

    public void OnMasterVolumeSliderValueChanged(float value)
    {
        Save.SaveIntProperty(SaveProperties.MasterVolume, (int)value);
    }

    public void OnFxVolumeSliderValueChanged(float value)
    {
        Save.SaveIntProperty(SaveProperties.SoundFxVolume, (int)value);
    }

    public void OnMusicVolumeSliderValueChanged(float value)
    {
        Save.SaveIntProperty(SaveProperties.MusicVolume, (int)value);
    }

    // ===========================================================
    // Private Methods
    // ===========================================================
}
