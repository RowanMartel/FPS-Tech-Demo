using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    GlobalVars globalVars;

    private void Start()
    {
        globalVars = GameObject.FindObjectOfType<GlobalVars>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            globalVars.playerDead = true;
        }
    }
}