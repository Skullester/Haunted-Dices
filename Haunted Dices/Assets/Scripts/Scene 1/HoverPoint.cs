using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPoint : MonoBehaviour
{
    public bool isDistanceAccept;

    [SerializeField]
    private Transform playerTrans;
    public bool isCursorEnter;
    private float sqrDistancePlayer = 3.5f;

    public bool isDistance()
    {
        isDistanceAccept =
            (playerTrans.position - transform.position).sqrMagnitude
            < sqrDistancePlayer * sqrDistancePlayer;
        return isDistanceAccept;
    }
}
