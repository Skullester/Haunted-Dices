using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsGame : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown resolutionDropdown;

    [SerializeField]
    private Slider sliderSoundEffects;

    [SerializeField]
    private Slider sliderMusic;

    void Start()
    {
        //Screen.resolutions
        resolutionDropdown.ClearOptions();
    }

    public void SlideMusicVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void SoundMute(bool isSoundMute)
    {
        AudioListener.pause = isSoundMute;
    }

    public void ChangeScreenState(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
