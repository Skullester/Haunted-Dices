using UnityEngine;
using UnityEngine.UI;

public class SettingsGame : MonoBehaviour
{
    private static bool isSoundOn = true;
    private static bool isBtnFullScreen = true;

    [SerializeField]
    private Slider sliderSoundEffects;

    [SerializeField]
    private Toggle toggleFullScreen;

    [SerializeField]
    private Slider sliderMusic;

    [SerializeField]
    private Toggle toggleSound;

    void Start()
    {
        Screen.fullScreen = isBtnFullScreen;
        toggleSound.isOn = !isSoundOn;
    }

    public void SlideMusicVolume()
    {
        AudioListener.volume = sliderMusic.value;
    }

    public void SoundMute()
    {
        AudioListener.pause = !AudioListener.pause;
        isSoundOn = !isSoundOn;
    }

    public void ChangeScreenState()
    {
        Screen.fullScreen = !Screen.fullScreen;
        isBtnFullScreen = Screen.fullScreen;
    }
}
