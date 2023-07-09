using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    void Start() { }

    void Update() { }

    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            Debug.Log("RBM");
    }
}
