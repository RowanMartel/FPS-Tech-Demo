using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    GlobalVars vars;

    void Start()
    {
        vars = FindObjectOfType<GlobalVars>();
    }
    void Update()
    {
        transform.position = vars.PlayerPos + new Vector3(0, 5, 0);
    }
}