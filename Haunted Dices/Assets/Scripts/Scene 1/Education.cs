using System.Collections;
using UnityEngine;

public class Education : MonoBehaviour
{
    [SerializeField]
    private CharacterMoving cm;
    private int count = 1;

    [SerializeField]
    private GameObject btn;

    [SerializeField]
    private GameObject[] objects;
    public static bool isEducationPassed; //костыль

    public void GotItButton()
    {
        if (count == objects.Length)
        {
            isEducationPassed = true;
            cm.enabled = true;
            gameObject.SetActive(false);
            return;
        }
        objects[count - 1].SetActive(false);
        objects[count++].SetActive(true);
    }

    private void Start()
    {
        if (isEducationPassed)
        {
            gameObject.SetActive(false);
            return;
        }
        cm.enabled = false;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.3f);
        objects[0].SetActive(true);
        btn.SetActive(true);
    }
}
