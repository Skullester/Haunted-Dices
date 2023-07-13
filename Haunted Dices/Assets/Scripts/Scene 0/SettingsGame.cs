using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using System.Linq;

public class SettingsGame : MonoBehaviour
{
    private bool isOn = true;

    [SerializeField]
    private Image imgBtn;

    [SerializeField]
    private Sprite[] spritesToggleSound;
    private int indexOfCurrentResolution;

    [SerializeField]
    private Toggle toggleFullScreen;

    [SerializeField]
    private TMP_Dropdown resolutionDropdown;

    [SerializeField]
    private AudioSource audioSourceMusic;

    [SerializeField]
    private AudioSource audioSourceSounds;

    [SerializeField]
    private AudioSource audioSourceCommon;

    [SerializeField]
    private Slider sliderSoundEffects;

    [SerializeField]
    private Slider sliderMusic;
    private Resolution[] resolutions;

    [SerializeField]
    private AudioClip[] clipSoundToggle;

    [SerializeField]
    private AudioClip[] songsRadio;

    private void Update()
    {
        if (!audioSourceMusic.isPlaying)
        {
            int index = UnityEngine.Random.Range(0, clipSoundToggle.Length + 1);
            audioSourceMusic.PlayOneShot(songsRadio[index]);
        }
    }

    void Awake()
    {
        audioSourceCommon.ignoreListenerPause = true;
        GetResolutions();
        LoadSettings(indexOfCurrentResolution);
    }

    public void SlideMusicVolume(float value)
    {
        audioSourceMusic.volume = value;
        PlayerPrefs.SetFloat("VolumeMusicSliderPref", value);
    }

    public void SlideSoundsVolume(float value)
    {
        PlayerPrefs.SetFloat("VolumeSoundsSliderPref", value);
        if (audioSourceSounds == null)
            return;
        audioSourceSounds.volume = value;
    }

    public void SoundMute()
    {
        isOn = !isOn;
        int index = Convert.ToInt32(isOn);
        imgBtn.sprite = spritesToggleSound[index];
        AudioListener.pause = !isOn;
        audioSourceCommon.PlayOneShot(clipSoundToggle[index]);
        PlayerPrefs.SetInt("VolumeMutedPref", index);
    }

    public void ChangeScreenState(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreenPref", isFullScreen ? 1 : 0);
    }

    public void SetScreenResolution(int indexOfOption)
    {
        Resolution resolution = resolutions[indexOfOption];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionPref", indexOfOption);
    }

    void GetResolutions()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions
            .Select(
                resolution =>
                    new Resolution { width = resolution.width, height = resolution.height }
            )
            .Distinct()
            .ToArray();
        List<string> listOptions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            int width = resolutions[i].width;
            int height = resolutions[i].height;
            string option = width + "x" + height;
            listOptions.Add(option);
            if (
                width == Screen.currentResolution.width && height == Screen.currentResolution.height
            )
                indexOfCurrentResolution = i;
        }
        resolutionDropdown.AddOptions(listOptions);
        resolutionDropdown.RefreshShownValue();
    }

    public void LoadSettings(int indexOfCurrentOption)
    {
        if (PlayerPrefs.HasKey("VolumeMutedPref"))
        {
            isOn = Convert.ToBoolean(PlayerPrefs.GetInt("VolumeMutedPref"));
            AudioListener.pause = !isOn;
            imgBtn.sprite = spritesToggleSound[Convert.ToInt32(isOn)];
        }

        if (PlayerPrefs.HasKey("VolumeMusicSliderPref"))
        {
            sliderMusic.value = PlayerPrefs.GetFloat("VolumeMusicSliderPref");
            audioSourceMusic.volume = sliderMusic.value;
        }
        if (PlayerPrefs.HasKey("VolumeSoundsSliderPref"))
        {
            sliderSoundEffects.value = PlayerPrefs.GetFloat("VolumeSoundsSliderPref");
            if (audioSourceSounds != null)
                audioSourceSounds.volume = sliderSoundEffects.value;
        }
        if (PlayerPrefs.HasKey("FullScreenPref"))
        {
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPref"));
            toggleFullScreen.isOn = Screen.fullScreen;
        }
        else
            Screen.fullScreen = true;
        if (PlayerPrefs.HasKey("ResolutionPref"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPref");
        else
            resolutionDropdown.value = indexOfCurrentResolution;
    }
}
