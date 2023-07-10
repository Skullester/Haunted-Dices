using UnityEngine;
using UnityEngine.UI;

public class ToggleSystem : MonoBehaviour
{
    [SerializeField]
    private Toggle[] toggles = new Toggle[4];

    void MissionCompleted(int indexTog)
    {
        toggles[indexTog].isOn = true;
    }
}
