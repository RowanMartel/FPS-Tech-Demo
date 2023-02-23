using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerPos : MonoBehaviour
{
    GlobalVars globalVars;

    void Start()
    {
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
    }

    void Update()
    {
        globalVars.PlayerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}