using UnityEngine;
using UnityEngine.UI;

public class SettingsGame : MonoBehaviour
{
    private static bool isSoundOn = true;
    private static bool isBtnFullScreen = true;

    [SerializeField]
    private Slider sliderSoundEffects;

    [SerializeField]
    private Image imgFullScreen;

    [SerializeField]
    private Slider sliderMusic;

    [SerializeField]
    private Toggle toggleSound;

    void Start()
    {
        toggleSound.isOn = !isSoundOn;
    }

    public void SlideMusicVolume()
    {
        AudioListener.volume = sliderMusic.value;
    }

    public void SoundMute()
    {
        if (toggleSound.isOn)
            AudioListener.pause = true;
        else
            AudioListener.pause = false;
        isSoundOn = !isSoundOn;
    }

    public void ChangeScreenState()
    {
        Screen.fullScreen = !Screen.fullScreen;
        if (isBtnFullScreen)
            imgFullScreen.color = Color.white;
        else
            imgFullScreen.color = Color.black;
        isBtnFullScreen = !isBtnFullScreen;
    }
}
