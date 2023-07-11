using UnityEngine;
using UnityEngine.UI;

public class ToggleSystem : MonoBehaviour
{
    [SerializeField]
    private Toggle[] numToggles = new Toggle[4];

    public void MissionCompleted(int indexTog)
    {
        numToggles[indexTog].isOn = true;
    }
}
