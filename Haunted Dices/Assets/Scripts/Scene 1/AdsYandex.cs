using UnityEngine;
using System.Runtime.InteropServices;

public class AdsYandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowFullscreen();

    public void Show1()
    {
        ShowFullscreen();
    }
}
