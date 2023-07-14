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

    public bool CheckWin()
    {
        int count = 0;
        for (int i = 0; i < numToggles.Length; i++)
        {
            if (numToggles[i].isOn)
                count += 1;
        }
        Debug.Log(count);
        if (count == 4)
            return true;
        return false;
    }
}
