using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    RodSpawner rodSpawner;
    GlobalVars globalVars;

    private void Start()
    {
        rodSpawner = GameObject.FindObjectOfType<RodSpawner>();
        globalVars = GameObject.Find("EventManager").GetComponent<GlobalVars>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (globalVars.playerWeapon)
            {
                case 1:
                    rodSpawner.SpawnItem();
                    break;
            }    
        }
    }
}