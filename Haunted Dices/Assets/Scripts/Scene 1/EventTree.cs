using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EventTree : MonoBehaviour
{
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

    void Awake()
    {
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
            victoryObj.SetActive(true);
    }

    public void FirstPointInteraction(int indexChar, int indexSkill) //0 Тело
    {
        Debug.Log("Нулевой поинт");
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[0]);
            points[1].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            indTog.MissionCompleted(0); //0-Who
            interactGameObj[0].SetActive(true);
            hint.CallHintMenu(text[1]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[2]);
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[3]);

            points[0].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[3].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void SecondPointInteraction(int indexChar, int indexSkill) //1 Игрушки
    {
        Debug.Log("Первый поинт");
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            indTog.MissionCompleted(3); //3-ByWhat

            hint.CallHintMenu(text[4]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            indTog.MissionCompleted(0); //0-Who
            indTog.MissionCompleted(3); //3-ByWhat

            hint.CallHintMenu(text[5]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[6]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[7]);

            points[2].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void ThirdPointInteraction(int indexChar, int indexSkill) //2 Закрытая дверь
    {
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[8]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[9]);
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[10]);
            interactGameObj[1].SetActive(false);
            points[2].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[5].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[11]);
        }
    }

    public void FourthPointInteraction(int indexChar, int indexSkill) //3 Письмо
    {
        Debug.Log("Третий поинт");
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[12]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[13]);

            points[3].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[6].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[14]);

            points[3].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[15]);

            points[3].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[7].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void FifthPointInteraction(int indexChar, int indexSkill) //4 Отпечатки ладоней
    {
        Debug.Log("Четвертый поинт");
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[16]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            indTog.MissionCompleted(0); //0-Who

            hint.CallHintMenu(text[17]);

            points[4].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[18]);
            points[4].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[19]);
            indTog.MissionCompleted(0); //0-Who
            points[4].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void SixthPointInteraction(int indexChar, int indexSkill) //5 Коробка с фильмами
    {
        Debug.Log("Пятый поинт");
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[20]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[21]);

            indTog.MissionCompleted(0); //0-Who
            indTog.MissionCompleted(1); //1-Why

            points[5].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            Debug.Log($"{indexChar}, {indexSkill}");
            hint.CallHintMenu(text[22]);

            points[5].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            Debug.Log($"{indexChar}, {indexSkill}");
            interactGameObj[4].gameObject.SetActive(true);
            hint.CallHintMenu(text[23]);
            gameOverobj.LockMovement();
            gameOverobj.gameObject.SetActive(true);
            Interaction.isButtonClicked = false;
            imgGameOver[0].enabled = true;
            eventDict.Clear();
        }
    }

    public void SeventhPointInteraction(int indexChar, int indexSkill) //6 Таинственная коробка
    {
        Debug.Log("Шестой поинт");
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

            points[6].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[8].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[27]);

            points[7].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void EighthPointInteraction(int indexChar, int indexSkill) //7 Ванна
    {
        Debug.Log("Седьмой поинт");
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            hint.CallHintMenu(text[28]);
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            indTog.MissionCompleted(1); //1-Why

            hint.CallHintMenu(text[29]);

            points[7].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[30]);
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            indTog.MissionCompleted(1); //1-Why

            hint.CallHintMenu(text[31]);

            points[7].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void NinthPointInteraction(int indexChar, int indexSkill) //8 Черный порошок
    {
        Debug.Log("Восьмой поинт");
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

            points[8].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[9].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[35]);
        }
    }

    public void TenthPointInteraction(int indexChar, int indexSkill) //9 Призрак
    {
        Debug.Log("Девятый поинт");
        if (indexChar == 0 & indexSkill == 0) // Мартин бескостный язык
        {
            indTog.MissionCompleted(0); //0-Who
            indTog.MissionCompleted(1); //1-Why
            indTog.MissionCompleted(2); //2-How
            indTog.MissionCompleted(3); //3-ByWhat

            hint.CallHintMenu(text[36]);

            points[9].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 0 & indexSkill == 1) // Мартин орлиный глаз
        {
            hint.CallHintMenu(text[37]);
        }
        if (indexChar == 1 & indexSkill == 0) // Шерон Идеальная отмычка
        {
            hint.CallHintMenu(text[38]);

            points[9].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (indexChar == 1 & indexSkill == 1) // Шерон Призрачная связь
        {
            hint.CallHintMenu(text[39]);

            points[9].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
