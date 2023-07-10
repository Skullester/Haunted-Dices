using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour
{
    [SerializeField]
    private List<Image> hearts;

    [SerializeField, Range(1, 3)]
    private int s_priceSkill;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(s_priceSkill);
        if (Input.GetButtonDown("Jump"))
        {
            for (int i = hearts.Count - 1; i > hearts.Count - 1 - s_priceSkill; i--)
            {
                Debug.Log("JOPA");
                hearts[i].enabled = false;
                hearts.RemoveAt(i);
            }
        }
    }
}
