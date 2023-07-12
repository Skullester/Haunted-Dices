using UnityEngine;
using TMPro;

public class HpSystem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textHp;
    private int maxHp = 36;

    void Awake()
    {
        Characters.Hp = maxHp;
    }

    public void ChangeNumberSouls(int priceSkill)
    {
        Characters.Hp -= priceSkill;
        Characters.Hp = Characters.Hp < 0 ? 0 : Characters.Hp;
        textHp.text = Characters.Hp.ToString();
    }
}
