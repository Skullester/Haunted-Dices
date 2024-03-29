using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private Animator animTransition;
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
        // if (volume.profile.TryGet<DepthOfField>(out var tmp))
        //s_dof = tmp;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetPause();
    }

    public void SetPause()
    {
        pauseUI.SetActive(true);
        //  s_dof.active = true;
        audioSourceSounds.mute = true;
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        pauseUI.SetActive(false);
        //s_dof.active = false;
        audioSourceSounds.mute = false;
        Time.timeScale = 1f;
    }

    public void ReturnToMenu()
    {
        if (warning.activeSelf || Characters.Hp == 0)
        {
            Interaction.isButtonClicked = false;
            Time.timeScale = 1f;
            animTransition.gameObject.SetActive(true);
            animTransition.SetTrigger("Start");
            StartCoroutine(DelayBetweenTrans());
        }
        warning.SetActive(true);
    }

    public void ReturnToMenu2()
    {
        Interaction.isButtonClicked = false;
        animTransition.gameObject.SetActive(true);
        animTransition.SetTrigger("Start");
        StartCoroutine(DelayBetweenTrans());
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

    public void RestartGame()
    {
        animTransition.gameObject.SetActive(true);
        animTransition.SetTrigger("Start");
        StartCoroutine(DelayBetweenTrans2());
    }

    IEnumerator DelayBetweenTrans2()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
