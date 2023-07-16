using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering.Universal;

public class EventTree : MonoBehaviour
{
    [SerializeField]
    private GameObject preGameOver;

    [SerializeField]
    private Animator animPreGameOver;

    [SerializeField]
    private AudioSource audioSourceSounds;

    [SerializeField]
    private List<AudioClip> soundsPoints;
    public static Dictionary<int, Action<int, int>> eventDict =
        new Dictionary<int, Action<int, int>>();

    [SerializeField]
    private GameObject victoryObj;

    [SerializeField]
    private Interaction hint;

    [SerializeField, TextArea]
    private string[] text;

    [SerializeField]
    private ToggleSystem indTog;

    [SerializeField]
    private Interaction[] points;

    [SerializeField]
    private Interaction gameOverobj;

    public Image[] imgGameOver;

    [SerializeField]
    private GameObject[] interactGameObj;

    [SerializeField]
    private Image[] winImages;

    public bool IsBoxFilmsWhy;
    public bool IsBathroomWhy;
    public bool IsGhostWhy;
    public static bool isTimePassed = true;

    void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    Interaction.SkillsUsed.Add((i, j, k), false);
                }
            }
        }

        eventDict.Clear();
        isTimePassed = true;
        eventDict.Add(0, FirstPointInteraction);
        eventDict.Add(1, SecondPointInteraction);
        eventDict.Add(2, ThirdPointInteraction);
        eventDict.Add(3, FourthPointInteraction);
        eventDict.Add(4, FifthPointInteraction);
        eventDict.Add(5, SixthPointInteraction);
        eventDict.Add(6, SeventhPointInteraction);
        eventDict.Add(7, EighthPointInteraction);
        eventDict.Add(8, NinthPointInteraction);
        eventDict.Add(9, TenthPointInteraction);
    }

    void Update()
    {
        if (indTog.CheckWin())
        {
            victoryObj.SetActive(true);
            if (IsBoxFilmsWhy && (IsBathroomWhy || IsGhostWhy)) // не только
                winImages[3].gameObject.SetActive(true);
            else if (IsBoxFilmsWhy && IsBathroomWhy == false && IsGhostWhy == false) // только
                winImages[2].gameObject.SetActive(true);
            else if (IsBoxFilmsWhy == false && (IsBathroomWhy || IsGhostWhy)) // не с помощью
                winImages[0].gameObject.SetActive(true);
        }
    }

    IEnumerator CheckBoxColider()
    {
        bool isColiderOn = false;
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < eventDict.Count; i++)
        {
            if (points[i].gameObject.GetComponent<BoxCollider>().enabled)
                isColiderOn = true;
        }
        if (!isColiderOn && !imgGameOver[1].enabled)
        {
            gameOverobj.gameOverObj.SetActive(true);
            Interaction.isButtonClicked = false;
            imgGameOver[2].enabled = true;
        }
    }

    public void FirstPointInteraction(int indexChar, int indexSkill) //0 Тело
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[8]);
            hint.CallHintMenu(text[0]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер игрушек
            interactGameObj[3].gameObject.GetComponent<Light2D>().enabled = true; // свет игрушек
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[1]);
            indTog.MissionCompleted(2); //2-How
            hint.CallHintMenu(text[1]);

            interactGameObj[2].SetActive(true); // картинка ладоней вкл
            interactGameObj[4].SetActive(true); // след к двери
            interactGameObj[5].SetActive(true); // свет у двери

            points[2].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер закрытой двери кладовой
            points[4].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[0]);
            hint.CallHintMenu(text[2]);
            interactGameObj[0].SetActive(false); // выкл спрайта у тела
            interactGameObj[1].SetActive(true); // вкл спрайт "вскрытый труп"
            interactGameObj[7].SetActive(true); // Появляется письмо
            points[0].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у тела отрубается

            points[3].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер у письма появляется
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[3]);
        }

        Interaction.SkillsUsed[(indexChar, indexSkill, 0)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }

    public void SecondPointInteraction(int indexChar, int indexSkill) //1 Игрушки
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[6]);
            indTog.MissionCompleted(1); //1-ByWhat
            hint.CallHintMenu(text[4]);
            points[1].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у игрушек пропадает
            interactGameObj[3].gameObject.GetComponent<Light2D>().enabled = false; // свет у кукол пропадает
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[6]);
            indTog.MissionCompleted(0); //0-Who
            indTog.MissionCompleted(1); //1-ByWhat
            hint.CallHintMenu(text[5]);
            points[1].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у игрушек пропадает
            interactGameObj[3].gameObject.GetComponent<Light2D>().enabled = false; //  свет пропадает у игрушек
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[6]);
            points[1].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер пропадает у игрушек
            interactGameObj[3].gameObject.GetComponent<Light2D>().enabled = false; // свет пропадает у игрушек
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[7]);

            points[2].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер закрытой двери появляется
            interactGameObj[5].SetActive(true); // свет у закрытой двери появляется
        }
        Interaction.SkillsUsed[(indexChar, indexSkill, 1)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }

    public void ThirdPointInteraction(int indexChar, int indexSkill) //2 Закрытая дверь
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[4]);
            hint.CallHintMenu(text[8]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[9]);
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[2]);
            hint.CallHintMenu(text[10]);
            interactGameObj[5].SetActive(false);
            interactGameObj[6].SetActive(false);
            points[2].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер закрытой двери пропадает

            points[5].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер коробки с фильмами появляется
            points[5].gameObject.GetComponent<Light2D>().enabled = true; // свет коробки с фильмами появляется
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[11]);
        }

        Interaction.SkillsUsed[(indexChar, indexSkill, 2)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }

    public void FourthPointInteraction(int indexChar, int indexSkill) //3 Письмо
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[12]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[13]);
            points[3].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер письма пропадает
            interactGameObj[7].gameObject.GetComponent<Light2D>().enabled = false; // свет письма пропадает

            points[6].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер коробки появляется
            interactGameObj[9].gameObject.GetComponent<Light2D>().enabled = true; // свет у коробки повляется
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[14]);

            points[3].gameObject.GetComponent<BoxCollider>().enabled = false;
            interactGameObj[7].gameObject.GetComponent<Light2D>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[15]);

            points[3].gameObject.GetComponent<BoxCollider>().enabled = false;
            interactGameObj[7].gameObject.GetComponent<Light2D>().enabled = false;

            points[7].gameObject.GetComponent<BoxCollider>().enabled = true;
            points[7].gameObject.GetComponent<Light2D>().enabled = true;
        }
        Interaction.SkillsUsed[(indexChar, indexSkill, 3)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }

    public void FifthPointInteraction(int indexChar, int indexSkill) //4 Отпечатки ладоней
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[5]);
            hint.CallHintMenu(text[16]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            indTog.MissionCompleted(0); //0-Who

            hint.CallHintMenu(text[17]);

            points[4].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у ладоней пропадает
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[18]);

            points[4].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у ладоней пропадает
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[19]);
            indTog.MissionCompleted(0); //0-Who

            points[4].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у ладоней пропадает
        }
        Interaction.SkillsUsed[(indexChar, indexSkill, 4)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }

    public void SixthPointInteraction(int indexChar, int indexSkill) //5 Коробка с фильмами
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[20]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[21]);

            indTog.MissionCompleted(0); //0-Who
            indTog.MissionCompleted(3); //3-Why

            IsBoxFilmsWhy = true;

            points[5].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у коробки с фильмами пропадает
            points[5].gameObject.GetComponent<Light2D>().enabled = false; // свет у коробки с фильмами пропадает
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[22]);
            points[5].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у коробки с фильмами пропадает
            points[5].gameObject.GetComponent<Light2D>().enabled = false; // свет у коробки с фильмами пропадает
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[3]);
            interactGameObj[8].SetActive(true); // демон появляется
            hint.CallHintMenu(text[23]);

            StartCoroutine(CloseHintMenu());
            gameOverobj.LockMovement();
        }
        Interaction.SkillsUsed[(indexChar, indexSkill, 5)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }

    IEnumerator CloseHintMenu()
    {
        yield return new WaitForSeconds(1.2f);
        preGameOver.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        gameOverobj.gameOverObj.SetActive(true);
        Interaction.isButtonClicked = false;
        imgGameOver[0].enabled = true;
    }

    IEnumerator TimerPoint()
    {
        yield return new WaitForSeconds(3.0f);
        isTimePassed = true;
    }

    public void SeventhPointInteraction(int indexChar, int indexSkill) //6 Таинственная коробка
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[24]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[25]);
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[26]);

            points[6].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер таинственный коробки пропадает
            interactGameObj[9].gameObject.GetComponent<Light2D>().enabled = false; // свет у закрытой коробки пропадает

            points[8].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер открытой коробки появляется
            interactGameObj[10].gameObject.GetComponent<Light2D>().enabled = true; // свет у открытой коробки появляется

            interactGameObj[9].SetActive(false); // спрайт у закрытой коробки пропадает
            interactGameObj[10].SetActive(true); // спрайт у открытой коробки появляется
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[27]);

            points[7].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер у ванны появляется
            points[7].gameObject.GetComponent<Light2D>().enabled = true; // свет у ванны появляется
        }
        Interaction.SkillsUsed[(indexChar, indexSkill, 6)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }

    public void EighthPointInteraction(int indexChar, int indexSkill) //7 Ванна
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[28]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            indTog.MissionCompleted(3); //3-Why
            IsBathroomWhy = true;

            hint.CallHintMenu(text[29]);

            points[7].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у ванны пропадает
            points[7].gameObject.GetComponent<Light2D>().enabled = false; // свет у ванны пропадает
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            indTog.MissionCompleted(3); //3-Why
            IsBathroomWhy = true;

            hint.CallHintMenu(text[30]);

            points[7].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер у ванны пропадает
            points[7].gameObject.GetComponent<Light2D>().enabled = false; // свет у ванны пропадает
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[31]);

            points[6].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер таинственной коробки появляется
            interactGameObj[9].gameObject.GetComponent<Light2D>().enabled = true; // свет у закрытой коробки появляется
        }
        Interaction.SkillsUsed[(indexChar, indexSkill, 7)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }

    public void NinthPointInteraction(int indexChar, int indexSkill) //8 Черный порошок
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[32]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[33]);
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[34]);
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            audioSourceSounds?.PlayOneShot(soundsPoints[7]);
            points[8].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер открытой коробки пропадает
            interactGameObj[10].GetComponent<Light2D>().enabled = false; // свет открытой коробки пропадает

            points[9].gameObject.GetComponent<BoxCollider>().enabled = true; // коллайдер призрака появляется
            points[9].gameObject.GetComponent<Light2D>().enabled = true; // спрайт у призрака появляется
            interactGameObj[11].SetActive(true); // спрайт призрака появляется
            hint.CallHintMenu(text[35]);
        }
        Interaction.SkillsUsed[(indexChar, indexSkill, 8)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }

    public void TenthPointInteraction(int indexChar, int indexSkill) //9 Призрак
    {
        if (!isTimePassed)
            return;
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            indTog.MissionCompleted(0); //0-Who
            indTog.MissionCompleted(3); //1-Why
            indTog.MissionCompleted(2); //2-How
            indTog.MissionCompleted(1); //1-ByWhat
            IsGhostWhy = true;
            hint.CallHintMenu(text[36]);
            points[9].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер призрака пропадает
            points[9].gameObject.GetComponent<Light2D>().enabled = false; // свет призрака пропадает
            interactGameObj[11].SetActive(false); // спрайт призрака пропадает
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[37]);
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[38]);
            points[9].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер призрака пропадает
            points[9].gameObject.GetComponent<Light2D>().enabled = false; // свет призрака пропадает
            interactGameObj[11].SetActive(false); // спрайт призрака пропадает
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[39]);
            points[9].gameObject.GetComponent<BoxCollider>().enabled = false; // коллайдер призрака пропадает
            points[9].gameObject.GetComponent<Light2D>().enabled = false; // свет призрака пропадает
            interactGameObj[11].SetActive(false); // спрайт призрака пропадает
        }
        Interaction.SkillsUsed[(indexChar, indexSkill, 9)] = true;
        isTimePassed = false;
        StartCoroutine(TimerPoint());
        StartCoroutine(CheckBoxColider());
    }
}
