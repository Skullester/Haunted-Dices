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
    public static bool isPassed;

    public void GotItButton()
    {
        if (count == objects.Length)
        {
            cm.enabled = true;
            gameObject.SetActive(false);
            isPassed = true;
            return;
        }
        objects[count - 1].SetActive(false);
        objects[count++].SetActive(true);
    }

    private void Start()
    {
        if (isPassed)
        {
            gameObject.SetActive(false);
            return;
        } /*  if (PlayerPrefs.HasKey("Education"))
         {
             gameObject.SetActive(false);
             return;
         } */
        cm.enabled = false;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.1f);
        objects[0].SetActive(true);
        btn.SetActive(true);
    }
}
