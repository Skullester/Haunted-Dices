using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class HpSystem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textHp;
    private int maxHp = 36;
    public static int currentHp;

    void Awake()
    {
        currentHp = maxHp;
    }

    public void ChangeNumberSouls(int priceSkill)
    {
        currentHp -= priceSkill;
        currentHp = currentHp < 0 ? 0 : currentHp;
        textHp.text = currentHp.ToString();
    }
}
