using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour
{
    [SerializeField, Space]
    private List<Image> hearts;

    [SerializeField, Min(1)]
    private int priceSkill;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            int countOfList = hearts.Count;
            for (int i = countOfList - 1; i > countOfList - 1 - priceSkill; i--)
            {
                hearts[i].enabled = false;
                hearts.RemoveAt(i);
            }
        }
    }
}
