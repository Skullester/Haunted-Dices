using UnityEngine;
using UnityEngine.UI;

public class ToggleSystem : MonoBehaviour
{
    [SerializeField]
    private Toggle[] numToggles = new Toggle[4];

    void MissionCompleted(int indexTog)
    {
        numToggles[indexTog].isOn = true;
    }
}
