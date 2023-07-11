using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour
{
    private List<Image> hearts = new List<Image>();
    private int maxHp = 12;
    public static int currentHp;

    void Awake()
    {
        currentHp = maxHp;
        for (int i = 0; i < maxHp; i++)
        {
            hearts.Add(transform.Find($"Image ({i})").gameObject.GetComponent<Image>());
        }
    }

    public void ChangeNumberSouls(int priceSkill, bool GameOver)
    {
        int countOfList = hearts.Count;
        priceSkill = GameOver ? hearts.Count : priceSkill;
        for (int i = countOfList - 1; i > countOfList - 1 - priceSkill; i--)
        {
            hearts[i].enabled = false;
            hearts.RemoveAt(i);
        }
        currentHp -= priceSkill;
    }
}
