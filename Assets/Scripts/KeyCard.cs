using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    bool collected;
    GlobalVars globalVars;

    void Start()
    {
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collected)
            return;
        else if (other.gameObject.layer == 7)
            Pickup();
    }

    void Pickup()
    {
        collected = true;
        GetComponent<MeshRenderer>().enabled = false;
        globalVars.keys++;
    }
}