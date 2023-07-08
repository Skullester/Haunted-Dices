using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using System.Linq;

public class SettingsGame : MonoBehaviour
{
    private int indexOfCurrentResolution;

    [SerializeField]
    private Toggle toggleVolumeMute;

    [SerializeField]
    private Toggle toggleFullScreen;

    [SerializeField]
    private TMP_Dropdown resolutionDropdown;

    [SerializeField]
    private AudioSource audioSourceMusic;

    [SerializeField]
    private AudioSource audioSourceSounds;

    [SerializeField]
    private Slider sliderSoundEffects;

    [SerializeField]
    private Slider sliderMusic;
    private Resolution[] resolutions;

    void Awake()
    {
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
        if (audioSourceSounds == null)
            return;
        audioSourceSounds.volume = value;
        PlayerPrefs.SetFloat("VolumeSoundsSliderPref", value);
    }

    public void SoundMute(bool isSoundMute)
    {
        AudioListener.pause = isSoundMute;
        PlayerPrefs.SetInt("VolumeMutedPref", isSoundMute ? 1 : 0);
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
            AudioListener.pause = Convert.ToBoolean(PlayerPrefs.GetInt("VolumeMutedPref"));
            toggleVolumeMute.isOn = AudioListener.pause;
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
                audioSourceSounds.volume = sliderMusic.value;
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
