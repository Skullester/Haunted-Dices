using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonOpacity : MonoBehaviour
{
    [SerializeField]
    private float alpha;

    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alpha;
    }
}
