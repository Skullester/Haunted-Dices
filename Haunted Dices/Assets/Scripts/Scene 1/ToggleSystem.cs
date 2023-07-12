using UnityEngine;
using UnityEngine.UI;

public class ToggleSystem : MonoBehaviour
{
    [SerializeField]
    private Toggle[] numToggles;

    public void MissionCompleted(int indexTog)
    {
        numToggles[indexTog].isOn = true;
    }
}
