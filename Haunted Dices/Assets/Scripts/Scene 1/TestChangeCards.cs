using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChangeCards : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Animator anim2;
    private int indexOfCharacter;
    private static int characterNumbers = 2;
    private Transform[] characters = new Transform[characterNumbers];
    private Transform selectedCardPos;

    void Awake()
    {
        characters[0] = transform.Find("Character 1 BTN");
        characters[1] = transform.Find("Character 2 BTN");
        selectedCardPos = characters[0];
    }

    // Update is called once per frame
    void Update() { }

    public void ChangeCharacter()
    {
        anim.SetBool("isChanging", true);
        anim2.SetBool("isChanging", true);
    }
}
