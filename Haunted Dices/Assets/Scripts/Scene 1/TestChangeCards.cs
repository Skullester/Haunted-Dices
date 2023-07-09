using System.Collections;
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

    void Awake()
    {
        characters[0] = transform.Find("Character 1 BTN");
        characters[1] = transform.Find("Character 2 BTN");
    }

    // Update is called once per frame
    void Update() { }

    public void ChangeCharacter()
    {
        anim.SetBool("IsChanging", true);
        anim2.SetBool("IsChanging", true);
        StartCoroutine(DelayAnim());
    }

    IEnumerator DelayAnim()
    {
        yield return new WaitForSeconds(0.5f);
        characters[0].SetAsFirstSibling();
    }
}
