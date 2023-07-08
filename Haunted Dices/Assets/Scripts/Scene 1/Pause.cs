using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Pause : MonoBehaviour
{
    private DepthOfField dof;
    private Volume volume;

    void Awake()
    {
        if (volume.profile.TryGet<DepthOfField>(out var tmp))
            dof = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            dof.active = true;
    }
}
