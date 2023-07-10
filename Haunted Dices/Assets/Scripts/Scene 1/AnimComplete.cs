using UnityEngine;
using UnityEngine.UI;

public class AnimComplete : MonoBehaviour
{
    private Animator toggleAnim;

    [SerializeField]
    private Toggle[] toggles = new Toggle[4];

    void MissionCompleted(int indexTog)
    {
        toggles[indexTog].isOn = true;
    }
}
