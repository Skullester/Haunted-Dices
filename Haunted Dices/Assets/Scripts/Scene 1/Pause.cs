using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private Animator animTransition;
    private DepthOfField dof;
    private AudioSource audioSourceMusic;

    [SerializeField]
    private AudioSource audioSourceSounds;

    [SerializeField]
    private Volume volume;
    private GameObject pauseUI;
    private GameObject settings;

    [SerializeField]
    private GameObject warning;

    void Awake()
    {
        audioSourceMusic = GetComponent<AudioSource>();
        settings = transform.Find("Settings").gameObject;
        pauseUI = transform.Find("PauseMenu").gameObject;
        if (volume.profile.TryGet<DepthOfField>(out var tmp))
            dof = tmp;
    }

    void Update() { }

    public void SetPause()
    {
        pauseUI.SetActive(true);
        dof.active = true;
        audioSourceSounds.mute = true;
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        pauseUI.SetActive(false);
        dof.active = false;
        audioSourceSounds.mute = false;
        Time.timeScale = 1f;
    }

    public void ReturnToMenu()
    {
        if (warning.activeSelf)
        {
            Time.timeScale = 1f;
            animTransition.gameObject.SetActive(true);
            animTransition.SetTrigger("Start");
            StartCoroutine(DelayBetweenTrans());
        }
        warning.SetActive(true);
    }

    public void CancelReturning()
    {
        warning.SetActive(false);
    }

    public void InteractSettings()
    {
        if (settings.activeSelf)
            settings.SetActive(false);
        else
            settings.SetActive(true);
    }

    IEnumerator DelayBetweenTrans()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
