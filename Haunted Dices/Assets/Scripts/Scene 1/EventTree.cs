using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private Interaction gameOver;

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
        if (indexChar == 0 & indexSkill == 0)
        {
            hint.CallHintMenu(text[0]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            indTog.MissionCompleted(0); //0-Who

            hint.CallHintMenu(text[1]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            hint.CallHintMenu(text[2]);
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            hint.CallHintMenu(text[3]);

            points[0].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[3].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void SecondPointInteraction(int indexChar, int indexSkill) //1 Игрушки
    {
        if (indexChar == 0 & indexSkill == 0)
        {
            indTog.MissionCompleted(3); //3-ByWhat

            hint.CallHintMenu(text[4]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            indTog.MissionCompleted(0); //0-Who
            indTog.MissionCompleted(3); //3-ByWhat

            hint.CallHintMenu(text[5]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            hint.CallHintMenu(text[6]);

            points[1].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            hint.CallHintMenu(text[7]);

            points[2].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void ThirdPointInteraction(int indexChar, int indexSkill) //2 Закрытая дверь
    {
        if (indexChar == 0 & indexSkill == 0)
        {
            Debug.Log($"{indexChar}, {indexChar}");
            hint.CallHintMenu(text[8]);
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            Debug.Log($"{indexChar}, {indexChar}");
            hint.CallHintMenu(text[9]);
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            hint.CallHintMenu(text[10]);

            points[2].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[5].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            hint.CallHintMenu(text[11]);
        }
    }

    public void FourthPointInteraction(int indexChar, int indexSkill) //3 Письмо
    {
        if (indexChar == 0 & indexSkill == 0)
        {
            hint.CallHintMenu(text[12]);
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            hint.CallHintMenu(text[13]);

            points[3].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[6].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            hint.CallHintMenu(text[14]);

            points[3].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[7].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            hint.CallHintMenu(text[15]);

            points[3].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void FifthPointInteraction(int indexChar, int indexSkill) //4 Отпечатки ладоней
    {
        if (indexChar == 0 & indexSkill == 0)
        {
            hint.CallHintMenu(text[16]);
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            indTog.MissionCompleted(0); //0-Who

            hint.CallHintMenu(text[17]);
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            indTog.MissionCompleted(0); //0-Who

            hint.CallHintMenu(text[18]);
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            hint.CallHintMenu(text[19]);
        }
    }

    public void SixthPointInteraction(int indexChar, int indexSkill) //5 Коробка с фильмами
    {
        if (indexChar == 0 & indexSkill == 0)
        {
            hint.CallHintMenu(text[20]);
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            indTog.MissionCompleted(0); //0-Who
            indTog.MissionCompleted(1); //1-Why

            hint.CallHintMenu(text[21]);

            points[5].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            hint.CallHintMenu(text[22]);
            //Метод GAME OVER
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            hint.CallHintMenu(text[23]);

            points[5].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void SeventhPointInteraction(int indexChar, int indexSkill) //6 Таинственная коробка
    {
        if (indexChar == 0 & indexSkill == 0)
        {
            hint.CallHintMenu(text[24]);
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            hint.CallHintMenu(text[25]);
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            hint.CallHintMenu(text[26]);

            points[6].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[8].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            hint.CallHintMenu(text[27]);

            points[7].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void EighthPointInteraction(int indexChar, int indexSkill) //7 Ванна
    {
        if (indexChar == 0 & indexSkill == 0)
        {
            hint.CallHintMenu(text[28]);
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            indTog.MissionCompleted(1); //1-Why

            hint.CallHintMenu(text[29]);

            points[7].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            hint.CallHintMenu(text[30]);
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            indTog.MissionCompleted(1); //1-Why

            hint.CallHintMenu(text[31]);

            points[7].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void NinthPointInteraction(int indexChar, int indexSkill) //8 Черный порошок
    {
        if (indexChar == 0 & indexSkill == 0)
        {
            hint.CallHintMenu(text[32]);
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            hint.CallHintMenu(text[33]);
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            hint.CallHintMenu(text[34]);

            points[8].gameObject.GetComponent<BoxCollider>().enabled = false;
            points[9].gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            hint.CallHintMenu(text[35]);
        }
    }

    public void TenthPointInteraction(int indexChar, int indexSkill) //9 Призрак
    {
        if (indexChar == 0 & indexSkill == 0)
        {
            indTog.MissionCompleted(0); //0-Who
            indTog.MissionCompleted(1); //1-Why
            indTog.MissionCompleted(2); //2-How
            indTog.MissionCompleted(3); //3-ByWhat

            hint.CallHintMenu(text[36]);

            points[9].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (indexChar == 0 & indexSkill == 1)
        {
            hint.CallHintMenu(text[37]);
        }
        else if (indexChar == 1 & indexSkill == 0)
        {
            hint.CallHintMenu(text[38]);

            points[9].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (indexChar == 1 & indexSkill == 1)
        {
            hint.CallHintMenu(text[39]);

            points[9].gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
